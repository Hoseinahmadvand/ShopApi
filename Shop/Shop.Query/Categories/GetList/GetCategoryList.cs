
using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Categories.Mapper;
using Shop.Query.Categories.DTOs;

namespace Shop.Query.Categories.GetList;

public record GetCategoryList : IQuery<List<CategoryDto>>;

internal class GetCategoryListHandler : IQueryHandler<GetCategoryList, List<CategoryDto>>
{
    private readonly ShopContext _context;

    public GetCategoryListHandler(ShopContext context)
    {
        _context = context;
    }

    public async Task<List<CategoryDto>> Handle(GetCategoryList request, CancellationToken cancellationToken)
    {
        var result =await _context.Categories.ToListAsync(cancellationToken);
        return result.Map();
    }
}
