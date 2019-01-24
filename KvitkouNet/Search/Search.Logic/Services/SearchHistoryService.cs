using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Search.Data.Models;
using Search.Data.Repositories;
using Search.Logic.Common.Models;

namespace Search.Logic.Services
{
    public class SearchHistoryService : ISearchHistoryService
    {
        private readonly IHistoryRepository _historyRepository;
        private readonly IMapper _mapper;

        public SearchHistoryService(IHistoryRepository historyRepository, IMapper mapper)
        {
            _historyRepository = historyRepository;
            _mapper = mapper;
        }

        public Task<SearchEntity> GetLastSearch(string userId)
        {
            return _historyRepository.GetLastSearch(userId);
        }

        public Task SaveLastSearch(SearchRequest request)
        {
            return _historyRepository.SaveLastSearchAsync(_mapper.Map<SearchEntity>(request));
        }

        public void Dispose()
        {
        }
    }
}
