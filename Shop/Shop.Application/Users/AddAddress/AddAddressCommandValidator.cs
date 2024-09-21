using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.Users.AddAddress
{
    public class AddAddressCommandValidator:AbstractValidator<AddAddressCommand> 
    {
        public AddAddressCommandValidator()
        {
            RuleFor(r => r.Name)
                .NotNull()
                .NotEmpty().WithMessage(ValidationMessages.required("نام"));

            RuleFor(r => r.Family)
                .NotNull()
                .NotEmpty().WithMessage(ValidationMessages.required("نام خانوادگی"));

            RuleFor(r => r.Shire)
             .NotNull()
             .NotEmpty().WithMessage(ValidationMessages.required("استان"));

            RuleFor(r => r.City)
             .NotNull()
             .NotEmpty().WithMessage(ValidationMessages.required("شهر"));

            

            RuleFor(r => r.NationalCode)
             .NotNull()
             .NotEmpty().WithMessage(ValidationMessages.required("کدملی"))
              .MaximumLength(10).WithMessage("کدملی نامعتبر است")
             .MinimumLength(10).WithMessage("کدملی نامعتبر است")
             .ValidNationalId();

            RuleFor(r => r.PostalCode)
             .NotNull()
             .NotEmpty().WithMessage(ValidationMessages.required("کدپستی"));

            RuleFor(r => r.PostalAddress)
             .NotNull()
             .NotEmpty().WithMessage(ValidationMessages.required("آدرس"));
        }
    }
}
