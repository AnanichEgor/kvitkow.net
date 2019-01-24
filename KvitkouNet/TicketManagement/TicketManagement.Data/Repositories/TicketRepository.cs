using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TicketManagement.Data.Context;
using TicketManagement.Data.DbModels;
using TicketManagement.Data.DbModels.DbEnums;
using TicketManagement.Data.Extensions;

namespace TicketManagement.Data.Repositories
{
    /// <summary>
    /// Класс для работы с базой
    /// </summary>
    public class TicketRepository : ITicketRepository
    {
        private readonly TicketContext _context;
        private readonly Page<Ticket> _page;

        public TicketRepository(TicketContext context, Page<Ticket> page)
        {
            _context = context;
            _page = page;
        }

        /// <summary>
        ///     Добавляет билет в БД
        /// </summary>
        /// <param name="ticket">Модель билета</param>
        /// <returns>Код ответа Create и добавленную модель</returns>
        public async Task<string> Add(Ticket ticket)
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
        public async Task Update(string id, Ticket ticket)
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
        ///     Получение всех билетов имеющихся в системе постранично
        /// </summary>
        /// <param name="index"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<Page<Ticket>> GetAllPagebyPage(int index,
            int pageSize)
        {
            _page.CurrentPage = index;
            _page.PageSize = pageSize;
            var query = _context.Tickets.AsQueryable();
            _page.TotalPages = await query.CountAsync();
            _page.Tickets = await query.Include(db => db.User)
                .Include(db => db.LocationEvent)
                .Include(db => db.SellerAdress)
                .Include(db => db.RespondedUsers)
                .OrderByDescending(p => p.CreatedDate)
                .Skip(index * pageSize)
                .Take(pageSize)
                .ToListAsync();
            return _page;
        }
    }
}