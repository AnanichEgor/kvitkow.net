using System;
using System.Collections.Generic;
using System.Text;

namespace KvitkouNet.Logic.Common.Models.Search
{
    public class SearchResult<T>
    {
        public IList<T> Items { get; set; }

        public int Total { get; set; }
    }
}
