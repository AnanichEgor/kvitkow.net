using System;

namespace TicketManagement.Logic.Exceptions
{
    public class UserBadRatingException : Exception
    {
        public UserBadRatingException(string message) : base(message)
        {

        }
    }
}
