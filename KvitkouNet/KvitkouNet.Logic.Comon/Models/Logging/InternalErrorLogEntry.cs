using System;
using System.Collections.Generic;
using System.Text;

namespace KvitkouNet.Logic.Common.Models.Logging
{
    public class InternalErrorLogEntry
    {
        public long Id { get; set; }
        
        public string TypeString { get; set; }

        public int HResult { get; set; }

        public string InnerExceptionString { get; set; }

        public string Message { get; set; }

        public string Source { get; set; }

        public string StackTrace { get; set; }

        public string TargetSiteName { get; set; }

        public DateTime Created { get; set; }
    }
}
