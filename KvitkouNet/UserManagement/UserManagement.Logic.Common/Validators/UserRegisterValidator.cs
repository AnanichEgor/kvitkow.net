using FluentValidation;
using UserManagement.Logic.Models;

namespace UserManagement.Logic.Validators
{
    public class UserRegisterValidator : AbstractValidator<UserRegisterModel>
    {
        public UserRegisterValidator()
        {
            RuleFor(x => x.Username).NotEmpty().Matches(@" ^[a - zA - Z][a - zA - Z0 - 9 - _\.]{5,15}$");
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.Password).NotEmpty().Length(6, 12).Matches(@" ^[a - zA - Z][a - zA - Z0 - 9 - _\.]$");
            RuleFor(x => x.ConfirmPassword).Equal(x => x.Password);
        }
    }
}
