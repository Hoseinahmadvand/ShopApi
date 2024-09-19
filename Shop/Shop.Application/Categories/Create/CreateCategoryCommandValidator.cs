using Common.Application.Validation;
using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Categories.Create
{
    public class CreateCategoryCommandValidator:AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator() 
        {
            RuleFor(r=>r.Title)
                .NotNull().NotEmpty().WithMessage(ValidationMessages.required("عنوان"));
            
            RuleFor(r=>r.Slug)
                .NotNull().NotEmpty().WithMessage(ValidationMessages.required("Slug"));
        }

    }
}
