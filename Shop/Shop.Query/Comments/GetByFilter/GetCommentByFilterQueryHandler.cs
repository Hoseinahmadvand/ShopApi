using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Comments.DTOs;
using Shop.Query.Comments.Mapper;

namespace Shop.Query.Comments.GetByFilter;

internal class GetCommentByFilterQueryHandler : IQueryHandler<GetCommentByFilterQuery, CommentFilterResult>
{
    private readonly ShopContext _shopContext;

    public GetCommentByFilterQueryHandler(ShopContext shopContext)
    {
        _shopContext = shopContext;
    }

    public async Task<CommentFilterResult> Handle(GetCommentByFilterQuery request, CancellationToken cancellationToken)
    {
        var @params=request.FilterParams;
        var result = _shopContext.Comments.OrderByDescending(c=>c.CreationDate).AsQueryable();

        if(@params.UserId != null ) 
           result=result.Where(c=>c.UserId==@params.UserId); 

        if(@params.Status != null ) 
           result=result.Where(c=>c.Status==@params.Status); 

        if(@params.StartDate != null ) 
           result=result.Where(c=>c.CreationDate<=@params.StartDate); 

        if(@params.EndDate != null )
            result = result.Where(c => c.CreationDate >= @params.EndDate);

        var skip = (@params.PageId - 1) * @params.Take;
        var model = new CommentFilterResult()
        {
            Data =await result.Skip(skip).Take(@params.Take)
            .Select(comment=>comment.MapFilterComment())
            .ToListAsync(cancellationToken),
            FilterParams =@params
        };
        model.GeneratePaging(result, @params.Take, @params.PageId);
        return model;
    }
}
