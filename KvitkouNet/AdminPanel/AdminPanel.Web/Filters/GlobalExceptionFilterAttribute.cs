using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AdminPanel.Web.Filters
{
	public class GlobalExceptionFilterAttribute : ExceptionFilterAttribute
	{
		public override Task OnExceptionAsync(ExceptionContext context)
		{

			return base.OnExceptionAsync(context);
		}
	}
}