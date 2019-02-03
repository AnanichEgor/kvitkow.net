using FluentValidation;
using Logging.Logic.Models.Filters;

namespace Logging.Web.Validators.Filters
{
    public class DealLogFilterValidator : BaseFilterValidator<DealLogFilter>
    {
        public DealLogFilterValidator()
        {
            RuleFor(f => f.Type)
                .NotEmpty();

            When(f => f.MinPrice.HasValue, () =>
            {
                RuleFor(f => f.MinPrice.Value)
                    .GreaterThanOrEqualTo(0);
            });

            When(f => f.MinPrice.HasValue && f.MaxPrice.HasValue, () =>
            {
                RuleFor(f => f.MinPrice.Value)
                    .LessThanOrEqualTo(f => f.MaxPrice.Value);
            });
        }
    }
}
