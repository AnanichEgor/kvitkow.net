using EasyNetQ;
using System;

namespace TicketManagement.Logic.Exceptions
{
   public class EasyNetQSendException : TimeoutException
    {
        public EasyNetQSendException(string message, Exception exception) : base(message, exception)
        {
           
        }
        public EasyNetQSendException(string message, Exception exception, string resultResponse) : base(message, exception)
        {
            this.resultResponse = resultResponse;
        }

        public string resultResponse { get; private set; }
        
    }
}
