using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Products.DTOs;
using Shop.Query.Products.Mapper;

namespace Shop.Query.Products.GetByFilter;

public class GetProductByFilterQueryHandler : IQueryHandler<GetProductByFilterQuery, ProductFilterResult>
{
    private readonly ShopContext _context;

    public GetProductByFilterQueryHandler(ShopContext context)
    {
        _context = context;
    }

    public async Task<ProductFilterResult> Handle(GetProductByFilterQuery request, CancellationToken cancellationToken)
    {
        var @params=request.FilterParams;
        var result = _context.Products.OrderByDescending(p => p.Id).AsSplitQuery();

        if(!string.IsNullOrWhiteSpace(@params.Title)) 
            result=result.Where(p=>p.Title.Contains(@params.Title)); 
        
        if(!string.IsNullOrWhiteSpace(@params.Slug)) 
            result=result.Where(p=>p.Slug==@params.Slug); 

        if(@params.Id !=null) 
            result=result.Where(p=>p.Id==@params.Id);

        var skip = (@params.PageId - 1) * @params.Take;
        var model = new ProductFilterResult() 
        {
            Data=result.Skip(skip).Take(@params.Take).Select(p=>p.MapListData()).ToList(),
            FilterParams = @params
        };
        model.GeneratePaging(result,@params.Take,@params.PageId);
        return model;
    }
}

