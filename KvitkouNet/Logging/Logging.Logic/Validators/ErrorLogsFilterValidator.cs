using FluentValidation;
using Logging.Logic.Dtos;

namespace Logging.Logic.Validators
{
	public class ErrorLogsFilterValidator : AbstractValidator<ErrorLogsFilterDto>
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