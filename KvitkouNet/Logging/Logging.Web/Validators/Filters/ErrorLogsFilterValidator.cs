using FluentValidation;
using Logging.Logic.Models.Filters;

namespace Logging.Web.Validators.Filters
{
	public class ErrorLogsFilterValidator : AbstractValidator<ErrorLogsFilter>
	{
		public ErrorLogsFilterValidator()
		{
		    CascadeMode = CascadeMode.StopOnFirstFailure;

		    When(f => f.DateFrom.HasValue && f.DateTo.HasValue, () =>
		    {
		        RuleFor(f => f.DateFrom.Value)
		            .LessThanOrEqualTo(f => f.DateTo.Value);
		    });
		}
	}
}