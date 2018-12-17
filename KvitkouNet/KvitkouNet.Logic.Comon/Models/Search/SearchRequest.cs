using System;
using System.Collections.Generic;
using System.Text;

namespace KvitkouNet.Logic.Common.Models.Search
{
    public abstract class SearchRequest
    {
        public int Offset { get; set; }
        public int Limit { get; set; }
    }
}
