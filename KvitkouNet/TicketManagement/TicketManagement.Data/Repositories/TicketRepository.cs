using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TicketManagement.Data.Context;
using TicketManagement.Data.DbModels;
using TicketManagement.Data.DbModels.DbEnums;
using TicketManagement.Data.Extensions;
using TicketManagement.Data.Factories;

namespace TicketManagement.Data.Repositories
{
    /// <summary>
    /// Класс для работы с базой
    /// </summary>
    public class TicketRepository : ITicketRepository
    {
        private readonly TicketContext _context;
        private readonly Page<Ticket> _page;

        public TicketRepository(RepositoryContextFactory context, Page<Ticket> page)
        {
            _context = context.CreateDbContext();
            _page = page;
        }

        /// <summary>
        ///     Добавляет билет в БД
        /// </summary>
        /// <param name="ticket">Модель билета</param>
        /// <returns>Код ответа Create и добавленную модель</returns>
        public async Task<string> Add(Ticket ticket)
        {
            //WARNING используется для замены стандартных значений swagerr'a
            //(чтобы рукчками каждый раз не править)
            //при связи с фронтом надо убрать 
            ticket.Id = null;
            ticket.User.UserInfoId = null;
            ticket.RespondedUsers = null;
            //WARNING
            var user = await _context.UserInfos.Include(info => info.UserTickets)
                .FirstOrDefaultAsync(info => info.UserInfoId == ticket.User.UserInfoId);
            if (user == null)
            {
                _context.Tickets.Add(ticket);
                await _context.SaveChangesAsync();
                return _context.Tickets.Last()
                    .Id;
            }

            user.UserTickets.Add(ticket);
            await _context.SaveChangesAsync();
            return _context.Tickets.Last()
                .Id;
        }

        /// <summary>
        ///     Обновление информации о билете в БД
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ticket">Модель билета</param>
        /// <returns></returns>
        public async Task Update(string id,
            Ticket ticket)
        {
            var origin = await _context.Tickets.Include(db => db.User)
                .Include(db => db.LocationEvent)
                .Include(db => db.SellerAdress)
                .Include(db => db.RespondedUsers)
                .SingleOrDefaultAsync(x => x.Id == id);

            if (origin == null) return;

            _context.Tickets.Remove(origin);
            _context.Tickets.Add(ticket);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        ///     Добавление пользователя в "я пойду"
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task AddRespondedUsers(string id, UserInfo user)
        {
            user.UserInfoId = null;
            var origin = await _context.Tickets
                .Include(db => db.RespondedUsers)
                .SingleOrDefaultAsync(x => x.Id == id);
            if (origin == null) return;
            origin.RespondedUsers.Add(user);
            _context.Tickets.Update(origin);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        ///     Удаление всех билетов в БД
        /// </summary>
        /// <returns></returns>
        public async Task DeleteAll()
        {
            _context.Tickets.RemoveRange(_context.Tickets.Include(db => db.User)
                .Include(db => db.LocationEvent)
                .Include(db => db.SellerAdress)
                .Include(db => db.RespondedUsers));
            await _context.SaveChangesAsync();
        }

        /// <summary>
        ///     Удаление билета с определенным Id в БД
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task Delete(string id)
        {
            var origin = await _context.Tickets.Include(db => db.User)
                .Include(db => db.LocationEvent)
                .Include(db => db.SellerAdress)
                .Include(db => db.RespondedUsers)
                .SingleOrDefaultAsync(x => x.Id == id);

            if (origin != null)
            {
                _context.Tickets.Remove(origin);
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        ///     Получение всех билет имеющихся в системе в БД
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Ticket>> GetAll()
        {
            return await _context.Tickets.Include(db => db.User)
                .Include(db => db.LocationEvent)
                .Include(db => db.SellerAdress)
                .Include(db => db.RespondedUsers)
                .AsNoTracking()
                .ToArrayAsync();
        }

        /// <summary>
        ///     Получение билета по Id в БД
        /// </summary>
        /// <param name="ticketIdGuid">Id билета</param>
        /// <returns></returns>
        public Task<Ticket> Get(string id)
        {
            return _context.Tickets.Include(db => db.User)
                .Include(db => db.LocationEvent)
                .Include(db => db.SellerAdress)
                .Include(db => db.RespondedUsers)
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        /// <summary>
        ///     Получение только актуальных билетов в БД
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Ticket>> GetAllActual()
        {
            var res = _context.Tickets.Include(db => db.User)
                .Include(db => db.LocationEvent)
                .Include(db => db.SellerAdress)
                .Include(db => db.RespondedUsers)
                .AsNoTracking()
                .Where(x => x.Status == (TicketStatusDb) 2);
            return await res.ToListAsync();
        }

        /// <summary>
        ///     Получение всех актуальных билетов имеющихся в системе постранично
        /// </summary>
        /// <param name="index">Номер текущей страницы</param>
        /// <param name="pageSize">Количество тикетов на страницу</param>
        /// <param name="onlyActual">Только актуальные билеты</param>
        /// <returns></returns>
        public async Task<Page<Ticket>> GetAllPagebyPage(int index,
            int pageSize,
            bool onlyActual = false)
        {
            if (index<1) return null;
            index = index - 1;
            _page.CurrentPage = index;
            _page.PageSize = pageSize;
            var query = _context.Tickets.AsQueryable();
            if (onlyActual)
            {
                _page.Tickets = await query.Include(db => db.User)
                    .Include(db => db.LocationEvent)
                    .Include(db => db.SellerAdress)
                    .Include(db => db.RespondedUsers)
                    .Where(x => x.Status == (TicketStatusDb) 2)
                    .OrderByDescending(p => p.CreatedDate)
                    .Skip(index * pageSize)
                    .Take(pageSize)
                    .ToListAsync();
                _page.TotalPages = await query.Where(x => x.Status == (TicketStatusDb) 2)
                                       .CountAsync() /
                                   pageSize;
                if (index > _page.TotalPages) return null;
            }
            else
            {
                _page.Tickets = await query.Include(db => db.User)
                    .Include(db => db.LocationEvent)
                    .Include(db => db.SellerAdress)
                    .Include(db => db.RespondedUsers)
                    .OrderByDescending(p => p.CreatedDate)
                    .Skip(index * pageSize)
                    .Take(pageSize)
                    .ToListAsync();
                _page.TotalPages = await query.CountAsync() / pageSize;
                if (index > _page.TotalPages) return null;
            }

            return _page;
        }
    }
}