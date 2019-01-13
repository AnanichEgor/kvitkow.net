using Chat.Logic.Models;
using FluentValidation;

namespace Chat.Logic.Validators
{
    public class RoomValidator : AbstractValidator<Room>
    {
        public RoomValidator()
        {
            RuleFor(x => x.Id)
                .Equal("0")
                .WithMessage("Id must be 0");

            RuleFor(x => x.IsPrivat)
                .NotEmpty();

            RuleFor(x => x.Name)
                .MaximumLength(2)
                .MaximumLength(5);
            RuleFor(x => x.OwnerId)
                .NotEmpty()
                .GreaterThanOrEqualTo(10);
        }
    }
}
