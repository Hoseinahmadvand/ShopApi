using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Comments.DTOs;
using Shop.Query.Comments.Mapper;

namespace Shop.Query.Comments.GetById;

internal class GetCommentByIdQueryHandler : IQueryHandler<GetCommentByIdQuery, CommentDto?>
{
   private readonly ShopContext _shopContext;

    public GetCommentByIdQueryHandler(ShopContext shopContext)
    {
        _shopContext = shopContext;
    }

    public async Task<CommentDto?> Handle(GetCommentByIdQuery request, CancellationToken cancellationToken)
    {
        var comments=await _shopContext.Comments.FirstOrDefaultAsync(c=>c.Id==request.CommentId,cancellationToken);
        
        return comments.Map();
    }
}
