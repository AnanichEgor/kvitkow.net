using FluentValidation;
using Dashboard.Logic.Models;

namespace Dashboard.Logic.Validators
{
    public class NewsValidator : AbstractValidator<News>
    {
        public NewsValidator()
        {
            RuleFor(news => news.EventLink).NotEmpty();
        }
    }
}
