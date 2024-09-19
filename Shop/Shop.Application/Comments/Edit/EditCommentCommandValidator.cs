using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.Comments.Edit
{
    public class EditCommentCommandValidator : AbstractValidator<EditCommentCommand>
    {
        public EditCommentCommandValidator()
        {
            RuleFor(r => r.Text)
                .NotEmpty()
                .MinimumLength(5).WithMessage(ValidationMessages.minLength("متن نطر", 5))
                .MaximumLength(500).WithMessage(ValidationMessages.maxLength("متن نطر", 500));
        }
    }
}


