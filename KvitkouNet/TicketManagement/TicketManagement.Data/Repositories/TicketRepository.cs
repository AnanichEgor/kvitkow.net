using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TicketManagement.Data.Context;
using TicketManagement.Data.DbModels;
using TicketManagement.Data.DbModels.Enums;

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
            return _context.Tickets.Last().TicketDbId;
        }

        /// <summary>
        ///     Обновление информации о билете в БД
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ticket">Модель билета</param>
        /// <returns></returns>
        public async Task Update(string id, TicketDb ticket)
        {
            var original = await _context.Tickets.FindAsync(ticket.TicketDbId);
            if (original == null) return;
            original.Name = ticket.Name;
            original.Price = ticket.Price;
            //add more property
            await _context.SaveChangesAsync();
        }

        /// <summary>
        ///     Удаление всех билетов в БД
        /// </summary>
        /// <returns></returns>
        public async Task DeleteAll()
        {
            var first = _context.Tickets.First();
            var last = _context.Tickets.Last();
            _context.RemoveRange(first, last);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        ///     Удаление билета с определенным Id в БД
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task Delete(string id)
        {
            var original = _context.Tickets.Find(id);
            if (original == null) return;
            _context.Tickets.Remove(original);
            await _context.SaveChangesAsync();
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
                .AsNoTracking()
                .ToArrayAsync();
        }

        /// <summary>
        ///     Получение билета по Id в БД
        /// </summary>
        /// <param name="ticketIdGuid">Id билета</param>
        /// <returns></returns>
        public async Task<TicketDb> Get(string id)
        {
            return await _context.Tickets.SingleOrDefaultAsync(x => x.TicketDbId == id);
        }

        /// <summary>
        ///     Получение только актуальных билетов в БД
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<TicketDb>> GetAllActual()
        {
            var res = _context.Tickets.Where(x => x.Status == (TicketStatusDb) 2);
            return await res.ToListAsync();
        }
    }
}