using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TicketManagement.Logic.Exceptions;

namespace TicketManagement.Web.Filters
{
    public class UserBadRatingExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is UserBadRatingException)
            {
                context.Result = new ForbidResult(context.Exception.Message);
                context.ExceptionHandled = true;
            }
        }
    }
}