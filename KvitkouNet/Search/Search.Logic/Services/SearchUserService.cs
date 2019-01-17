using System.Threading.Tasks;
using Search.Data.Repositories;
using Search.Logic.Common.Models;

namespace Search.Logic.Services
{
    public class SearchUserService : ISearchUserService
    {
        private readonly IUserRepository _userRepository;

        public SearchUserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<SearchResult<UserInfo>> Search(UserSearchRequest request)
        {
            return _userRepository.SearchAsync(request);
        }

        public void Dispose()
        {
        }
    }
}
