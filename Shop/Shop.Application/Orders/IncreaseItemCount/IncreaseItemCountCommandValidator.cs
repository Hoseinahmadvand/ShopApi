using FluentValidation;

namespace Shop.Application.Orders.IncreaseItemCount
{
    public class IncreaseItemCountCommandValidator:AbstractValidator<IncreaseItemCountCommand> 
    {
        public IncreaseItemCountCommandValidator() 
        {
            {
                RuleFor(r => r.Count)
                    .GreaterThanOrEqualTo(1).WithMessage("تعداد باید بیشتر از 0 باشد .");
            }
        }

    }
}
