using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.Users.Create
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
           
            RuleFor(r=>r.Password)
                .NotEmpty().WithMessage(ValidationMessages.required(" کلمه عبور"))
                .NotNull().WithMessage(ValidationMessages.required(" کلمه عبور"))
                .MinimumLength(6).WithMessage("کلمه عبور نمیتواند کمتر از 6 کارکتر باشد.");
            RuleFor(r=>r.Email)
                .NotEmpty().WithMessage(ValidationMessages.required(" ایمیل"))
                .EmailAddress();
        }
    }
}
