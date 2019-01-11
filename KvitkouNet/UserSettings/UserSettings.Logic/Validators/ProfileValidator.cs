using FluentValidation;
using UserSettings.Logic.Models;

namespace UserSettings.Logic.Validators
{
	public class ProfileValidator: AbstractValidator<Profile>
	{
		public ProfileValidator()
		{
			RuleFor(x => x.FirstName)
				.NotEmpty();
			RuleFor(x => x.LastName)
				.NotEmpty();
		}
	}
}
