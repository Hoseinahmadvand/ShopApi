using Common.Application;
using Shop.Domain.CommentAgg.Repository;

namespace Shop.Application.Comments.ChangeStatus
{
    public class ChangeStatusCommandHandler : IBaseCommandHandler<ChangeStatusCommand>
    {
        private readonly ICommentRepository _repository;

        public ChangeStatusCommandHandler(ICommentRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(ChangeStatusCommand request, CancellationToken cancellationToken)
        {
            var comment = await _repository.GetTracking(request.Id);

            if (comment == null )
                return OperationResult.NotFound();

            comment.ChangeStatus(request.Status);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
