using FluentValidation;
using Logging.Logic.Models.Filters;

namespace Logging.Logic.Validators
{
	public class ErrorLogsFilterValidator : AbstractValidator<ErrorLogsFilter>
	{
		//TODO custom validation message
		public ErrorLogsFilterValidator()
		{
			RuleFor(_ => _.ExceptionTypeName)
				.NotNull()
				.Length(5, 50);
		}
	}
}