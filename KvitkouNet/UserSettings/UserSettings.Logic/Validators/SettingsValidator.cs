using FluentValidation;
using UserSettings.Logic.Models;

namespace UserSettings.Logic.Validators
{
	public class SettingsValidator : AbstractValidator<Settings>
	{
		public SettingsValidator()
		{
			RuleFor(x => x.UserId).NotNull();
			RuleFor(x => x.Profile.FirstName)
				.NotEmpty();
			RuleFor(x => x.Profile.LastName)
				.NotEmpty();
			RuleFor(x => x.Account.Email)
				.EmailAddress();
		}
	}
}
