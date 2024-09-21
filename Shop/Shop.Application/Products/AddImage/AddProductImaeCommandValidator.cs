using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.Products.AddImage
{
    public class AddProductImaeCommandValidator:AbstractValidator<AddProductImaeCommand> 
    {
        public AddProductImaeCommandValidator() 
        {
            RuleFor(r=>r.ImageFile)
                .NotNull().WithMessage(ValidationMessages.required("عکس"))
                .JustImageFile();
            RuleFor(r => r.Sequence)
                .GreaterThan(0);
        }

    }
}

