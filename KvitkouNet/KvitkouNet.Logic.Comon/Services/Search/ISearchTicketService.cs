using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using KvitkouNet.Logic.Common.Models.Search;

namespace KvitkouNet.Logic.Common.Services.Search
{
    public interface ISearchTicketService : IDisposable
    {
        /// <summary>
        /// Searches the tickets according to the specified <paramref name="request"/>.
        /// </summary>
        Task<SearchResult<TicketInfo>> Search(TicketSearchRequest request);
    }
}
