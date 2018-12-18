using System;
using System.Collections.Generic;
using System.Text;

namespace KvitkouNet.Logic.Common.Models.Search
{
    /// <summary>
    /// Contains information for user search request.
    /// </summary>
    /// <seealso cref="KvitkouNet.Logic.Common.Models.Search.SearchRequest" />
    public class UserSearchRequest : SearchRequest
    {
        /// <summary>
        /// Gets or sets the minimum user rating for search.
        /// </summary>
        public double? MinRating { get; set; }
    }
}
