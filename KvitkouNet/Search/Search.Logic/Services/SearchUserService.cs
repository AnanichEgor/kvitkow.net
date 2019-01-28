using System.Threading.Tasks;
using Search.Data.Repositories;
using Search.Logic.Common.Models;

namespace Search.Logic.Services
{
    public class SearchUserService : ISearchUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ISearchHistoryService _historyService;

        public SearchUserService(IUserRepository userRepository, ISearchHistoryService historyService)
        {
            _userRepository = userRepository;
            _historyService = historyService;
        }

        public async Task<SearchResult<UserInfo>> Search(UserSearchRequest request)
        {
            await _historyService.SaveLastSearchAsync(request);
            return await _userRepository.SearchAsync(request);
        }

        public void Dispose()
        {
        }
    }
}
