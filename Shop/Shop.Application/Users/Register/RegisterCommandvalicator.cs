using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.Users.Register
{
    public class RegisterCommandvalicator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandvalicator()
        {
            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage(ValidationMessages.required("شماره موبایل"));

            RuleFor(r => r.Password)
               .NotEmpty().WithMessage(ValidationMessages.required(" کلمه عبور"))
               .NotNull().WithMessage(ValidationMessages.required(" کلمه عبور"))
               .MinimumLength(6).WithMessage("کلمه عبور نمیتواند کمتر از 6 کارکتر باشد.");
        }
    }
}
