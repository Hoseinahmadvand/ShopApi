using Common.Application;
using Shop.Domain.CommentAgg.Repository;

namespace Shop.Application.Comments.Edit
{
    public class EditCommentCommandHnadler : IBaseCommandHandler<EditCommentCommand>
    {
        private readonly ICommentRepository _repository;

        public EditCommentCommandHnadler(ICommentRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(EditCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = await _repository.GetTracking(request.Id);

            if (comment == null || comment.UserId != request.UserId)
                return OperationResult.NotFound();

            comment.Edit(request.Text);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}


