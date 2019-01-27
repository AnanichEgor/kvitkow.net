using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Search.Data.Models;

namespace Search.Data.Repositories
{
    public interface IHistoryRepository
    {
        Task<SearchEntity> GetLastSearch(string userId);

        Task SaveLastSearchAsync(SearchEntity entity);
    }
}
