﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TicketManagement.Data.Context;
using TicketManagement.Data.DbModels;
using TicketManagement.Data.DbModels.Enums;
using TicketManagement.Data.Extensions;

namespace TicketManagement.Data.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly TicketContext _context;

        public TicketRepository(TicketContext context)
        {
            _context = context;
        }

        /// <summary>
        ///     Добавляет билет в БД
        /// </summary>
        /// <param name="ticket">Модель билета</param>
        /// <returns>Код ответа Create и добавленную модель</returns>
        public async Task<string> Add(TicketDb ticket)
        {
            _context.Tickets.Add(ticket);
            await _context.SaveChangesAsync();
            return _context.Tickets.Last().Id;
        }

        /// <summary>
        ///     Обновление информации о билете в БД
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ticket">Модель билета</param>
        /// <returns></returns>
        public async Task Update(string id, TicketDb ticket)
        {
            var original = await _context.Tickets.FindAsync(id);
            if (original == null) return;
            await Delete(id);
            _context.Tickets.Add(original.UpdateModel(ticket, id));
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
        public async Task<IEnumerable<TicketDb>> GetAll()
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
        public Task<TicketDb> Get(string id)
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
        public async Task<IEnumerable<TicketDb>> GetAllActual()
        {
            var res = _context.Tickets.Include(db => db.User)
                .Include(db => db.LocationEvent)
                .Include(db => db.SellerAdress)
                .Include(db => db.RespondedUsers)
                .AsNoTracking()
                .Where(x => x.Status == (TicketStatusDb) 2);
            return await res.ToListAsync();
        }
    }
}