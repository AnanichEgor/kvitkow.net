using EasyNetQ;
using System;

namespace TicketManagement.Logic.Exceptions
{
    class EasyNetQSendException : EasyNetQException
    {
        public EasyNetQSendException(string message, Exception exception) : base(message, exception)
        {
            this.resultResponse = resultResponse;
        }
        public EasyNetQSendException(string message, Exception exception, string resultResponse) : base(message, exception)
        {
            this.resultResponse = resultResponse;
        }

        public string resultResponse { get; private set; }

    }
}
