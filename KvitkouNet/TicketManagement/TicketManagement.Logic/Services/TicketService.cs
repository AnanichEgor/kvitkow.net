using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EasyNetQ;
using FluentValidation;
using KvitkouNet.Messages.TicketManagement;
using Microsoft.Extensions.Configuration;
using Polly;
using TicketManagement.Data.Repositories;
using TicketManagement.Logic.Exceptions;
using TicketManagement.Logic.Models;

namespace TicketManagement.Logic.Services
{
    /// <summary>
    ///     Сервис для работы с тикетами
    /// </summary>
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _context;
        private readonly IMapper _mapper;
        private readonly IValidator _validatorTickets;
        private readonly IConfiguration _configuration;
        private readonly IBus _bus;
        private readonly IValidator<UserInfo> _validatorUsers;

        public TicketService(ITicketRepository context,
            IMapper mapper,
            IValidator<Ticket> validatorTickets,
            IConfiguration configuration,
            IBus bus,
            IValidator<UserInfo> validatorUsers)
        {
            _context = context;
            _mapper = mapper;
            _validatorTickets = validatorTickets;
            _configuration = configuration;
            _bus = bus;
            _validatorUsers = validatorUsers;
        }

        /// <summary>
        ///     Добавляет билет
        /// </summary>
        /// <param name="ticket">Модель билета</param>
        /// <returns>Код ответа Create и добавленную модель</returns>
        public async Task<ResponseModel> Add(Models.Ticket ticket)
        {
            //WARNING используется для замены стандартных значений swagerr'a
            //при связи с фронтом надо убрать 
            ticket.SellerPhone = "+375-29-76-23-371";
            //WARNING
            if (ticket.User.Rating < 0)
                return new ResponseModel
                {
                    Status = RequestStatus.BadUserRating,
                    Message = "Bad user rating"
                };
            var validationResultTicket = await _validatorTickets.ValidateAsync(ticket);
            var validationResultUser = await _validatorUsers.ValidateAsync(ticket.User);
            if (!validationResultTicket.IsValid | !validationResultUser.IsValid)
            {
                var errors = validationResultTicket.Errors.ToList();
                errors.AddRange(validationResultUser.Errors.ToArray());
                return  new ResponseModel
                {
                    Status = RequestStatus.InvalidModel,
                    Message = "Invalid model",
                    ValidationFailures = errors
                };
            }

            var res = await _context.Add(_mapper.Map<Ticket>(ticket));
            var policy = Policy.Handle<TimeoutException>()
                .WaitAndRetryAsync(new[]
                {
                    TimeSpan.FromSeconds(1)
                });
            try
            {
                await policy.ExecuteAsync(async () =>
                {
                    await _bus.PublishAsync(new TicketCreationMessage
                    {
                        TicketId = res,
                        Price = ticket.Price,
                        Name = ticket.Name,
                        City = ticket.LocationEvent.City,
                        Category = ticket.TypeEvent.ToString(),
                        Date = DateTime.Now
                    });
                });
            }
            catch (TimeoutException exception)
            {
                Debug.WriteLine(exception);
                return
                    new ResponseModel
                    {
                        Status = RequestStatus.SuccessWithErrors,
                        Message = "Ticket added in db, but error sending message to RabbitMQ",
                        ExceptionMessage = exception.Message,
                        ExceptionSource = exception.Source,
                        Data = res
                    };
            }

            return  new ResponseModel();
        }

        /// <summary>
        ///     Обновление информации о билете
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ticket">Модель билета</param>
        /// <returns></returns>
        public async Task<ResponseModel> Update(string id, Models.Ticket ticket)
        {
            await _context.Update(id, _mapper.Map<Ticket>(ticket));
            var policy = Policy.Handle<TimeoutException>().WaitAndRetryAsync(new[] { TimeSpan.FromSeconds(1) });
            try
            {
                await policy.ExecuteAsync(async () =>
                {
                    await _bus.PublishAsync(new TicketUpdatedMessage()
                    {
                        TicketId = id,
                        Price = ticket.Price,
                        Name = ticket.Name,
                        City = ticket.LocationEvent.City,
                        Category = ticket.TypeEvent.ToString(),
                        Date = DateTime.Now
                    });
                });
            }
            catch (TimeoutException exception)
            {
                Debug.WriteLine(exception);
                return new ResponseModel
                    {
                    Status = RequestStatus.SuccessWithErrors,
                    Message = "Ticket added in db, but error sending message to RabbitMQ",
                    ExceptionMessage = exception.Message,
                    ExceptionSource = exception.Source
                };
            }
            return new ResponseModel();
        }

        /// <summary>
        ///     Добавление пользователя в "я пойду"
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ResponseModel> AddRespondedUsers(string id, UserInfo user)
        {
            if (!_validatorTickets.Validate(user).IsValid) return new ResponseModel(){Status = RequestStatus.InvalidModel, Message = "Invalid model" };
            await _context.AddRespondedUsers(id, _mapper.Map<Data.DbModels.UserInfo>(user));
            return new ResponseModel();
        }

        /// <summary>
        ///     Удаление всех билетов
        /// </summary>
        /// <returns></returns>
        public async Task<ResponseModel> DeleteAll()
        {
            await _context.DeleteAll();
            return new ResponseModel();
        }

        /// <summary>
        ///     Удаление билета с определенным Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ResponseModel> Delete(string id)
        {
            await _context.Delete(id);
            var policy = Policy.Handle<TimeoutException>().WaitAndRetryAsync(new[] { TimeSpan.FromSeconds(1) });
            try
            {
                await policy.ExecuteAsync(async () =>
                {
                    await _bus.PublishAsync(new TicketDeletedMessage
                    {
                        TicketId = id
                    });
                });
            }
            catch (TimeoutException exception)
            {
                Debug.WriteLine(exception);
                return new ResponseModel
                {
                    Status = RequestStatus.SuccessWithErrors,
                    Message = "Ticket added in db, but error sending message to RabbitMQ",
                    ExceptionMessage = exception.Message,
                    ExceptionSource = exception.Source
                };
            }
            return new ResponseModel();
        }

        /// <summary>
        ///     Получение всех билет имеющихся в системе
        /// </summary>
        /// <returns></returns>
        public async Task<ResponseModel> GetAll()
        {
            var res = _mapper.Map<IEnumerable<Models.Ticket>>(await _context.GetAll());
            return new ResponseModel();
        }

        /// <summary>
        ///     Получение билета по Id
        /// </summary>
        /// <returns></returns>
        public async Task<ResponseModel> Get(string id)
        {
            var res = _mapper.Map<Models.Ticket>(await _context.Get(id));
            return  new ResponseModel();
        }

        /// <summary>
        ///     Получение только актуальных билетов
        /// </summary>
        /// <returns></returns>
        public async Task<ResponseModel> GetAllActual()
        {
            var res = _mapper.Map<IEnumerable<Models.Ticket>>(await _context.GetAllActual());
            return new ResponseModel();
        }

        /// <summary>
        ///     Получение всех билетов имеющихся в системе постранично
        /// </summary>
        /// <param name="index">Номер текущей страницы</param>
        /// <returns></returns>
        public async Task< ResponseModel> GetAllPagebyPage(int index)
        {
            var pageSize = _configuration.GetValue<int>("pageSize");
            var res = _mapper.Map<Models.Page<TicketLite>>( await _context.GetAllPagebyPage(index, pageSize));
            return  new ResponseModel(){Data = res};
        }

        /// <summary>
        ///     Получение всех актуальных билетов имеющихся в системе постранично
        /// </summary>
        /// <param name="index">Номер текущей страницы</param>
        /// <param name="onlyActual">Только актуальные билеты</param>
        /// <returns></returns>
        public async Task< ResponseModel> GetAllPagebyPageActual(int index, bool onlyActual = true)
        {
            var pageSize = _configuration.GetValue<int>("pageSize");
            var res = _mapper.Map<Models.Page<TicketLite>>(await _context.GetAllPagebyPage(index, pageSize,onlyActual));
            return new ResponseModel();
        }

        /// <summary>
        ///     Disposing
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}