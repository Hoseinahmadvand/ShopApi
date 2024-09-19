using Common.Application;

namespace Shop.Application.Comments.Edit
{
    public record EditCommentCommand(long Id,long UserId, string Text) : IBaseCommand;
}


