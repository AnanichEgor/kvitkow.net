using System;
using System.Collections.Generic;
using System.Text;

namespace Security.Data.Exceptions
{
    public class SecurityDbException : Exception
    {
        public SecurityDbException(string message) : base(message)
        {
        }
    }
}
