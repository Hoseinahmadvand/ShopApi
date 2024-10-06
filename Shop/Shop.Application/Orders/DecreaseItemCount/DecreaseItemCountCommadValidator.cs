using FluentValidation;

namespace Shop.Application.Orders.DecreaseItemCount
{
    public class DecreaseItemCountCommadValidator:AbstractValidator<DecreaseOrderItemCountCommand>
    {
        public DecreaseItemCountCommadValidator()
        {

            RuleFor(r => r.Count)
                .GreaterThanOrEqualTo(1).WithMessage("تعداد باید بیشتر از 0 باشد .");

        }
    }
}
