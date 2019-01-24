using System.Threading.Tasks;
using Search.Data.Context;
using Search.Data.Models;

namespace Search.Data.Repositories
{
    public class HistoryRepository : IHistoryRepository
    {
        private readonly SearchContext _context;

        public HistoryRepository(SearchContext context)
        {
            _context = context;
        }

        public Task<SearchEntity> GetLastSearch(string userId)
        {
            return _context.SearchEntities.FindAsync(userId);
        }

        public async Task SaveLastSearchAsync(SearchEntity entity)
        {
           await _context.SearchEntities.AddAsync(entity);
           await _context.SaveChangesAsync();
        }
    }
}
