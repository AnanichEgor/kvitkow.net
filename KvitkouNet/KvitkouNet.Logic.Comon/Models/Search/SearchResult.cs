using System;
using System.Collections.Generic;
using System.Text;

namespace KvitkouNet.Logic.Common.Models.Search
{
    /// <summary>
    /// Contains result information after search request.
    /// </summary>
    public class SearchResult<T>
    {
        /// <summary>
        /// Gets or sets the items after search request for 1 page.
        /// </summary>
        public IList<T> Items { get; set; }

        /// <summary>
        /// Gets or sets the total count of items after search request.
        /// </summary>
        public int Total { get; set; }
    }
}
