using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.Users.Edit
{
    public class EditUserCommandValidator:AbstractValidator<EditUserCommand> 
    {
        public EditUserCommandValidator()
        {
          
          
            RuleFor(r => r.Email)
                .NotEmpty().WithMessage(ValidationMessages.required(" ایمیل"))
                .EmailAddress();

            RuleFor(r => r.Avatar)
                .JustImageFile();
        }
    }
}
