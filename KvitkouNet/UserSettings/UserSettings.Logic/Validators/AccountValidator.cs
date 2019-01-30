using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using UserSettings.Logic.Models;

namespace UserSettings.Logic.Validators
{
	public class AccountValidator : AbstractValidator<Account>
	{
		public AccountValidator()
		{
			RuleFor(x => x.Account.Email)
				.EmailAddress();
		}
	}
}
