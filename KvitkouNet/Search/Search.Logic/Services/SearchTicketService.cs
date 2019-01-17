using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Search.Data.Repositories;
using Search.Logic.Common.Models;

namespace Search.Logic.Services
{
    public class SearchTicketService : ISearchTicketService
    {
        private readonly ITicketRepository _ticketRepository;

        public SearchTicketService(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public Task<SearchResult<TicketInfo>> Search(TicketSearchRequest request)
        {
            return _ticketRepository.SearchAsync(request);
        }

        public void Dispose()
        {
        }

    }
}
