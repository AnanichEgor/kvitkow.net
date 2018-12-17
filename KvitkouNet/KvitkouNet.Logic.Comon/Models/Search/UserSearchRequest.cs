using System;
using System.Collections.Generic;
using System.Text;

namespace KvitkouNet.Logic.Common.Models.Search
{
    public class UserSearchRequest : SearchRequest
    {
        public double? MinRating { get; set; }
    }
}
