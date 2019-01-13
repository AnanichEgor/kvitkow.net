using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Nest;
using Search.Logic.Common.Models;

namespace Search.Data.Repositories
{
    public class ElasticSearchUserRepository : ElasticSearchRepository<UserInfo>, IUserRepository
    {
        public ElasticSearchUserRepository(IElasticClient client) : base(client)
        {
        }

        Task<SearchResult<UserInfo>> IUserRepository.SearchAsync(UserSearchRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
