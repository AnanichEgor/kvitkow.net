using KvitkouNet.Logic.Common.Models.Logging.Abstraction;

namespace KvitkouNet.Logic.Common.Models.Logging
{
    public class InternalErrorLogEntry : BaseLogEntry<int>
    {
        public string TypeString { get; set; }

        public int HResult { get; set; }

        public string InnerExceptionString { get; set; }

        public string Message { get; set; }

        public string Source { get; set; }

        public string StackTrace { get; set; }

        public string TargetSiteName { get; set; }
    }
}
