using System.Threading.Tasks;
using EasyNetQ;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AdminPanel.Web.Filters
{
	public class GlobalExceptionFilter : ExceptionFilterAttribute
	{
		private readonly IBus _bus;

		public GlobalExceptionFilter(IBus bus)
		{
			_bus = bus;
		}

		public override Task OnExceptionAsync(ExceptionContext context)
		{
			_bus.Publish("hello");
			return base.OnExceptionAsync(context);
		}
	}
}