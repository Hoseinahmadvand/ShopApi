using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Orders.DTOs;
using Shop.Query.Orders.Mapper;

namespace Shop.Query.Orders.GetByFilter;

internal class GetOrderByFilterHandler : IQueryHandler<GetOrderByFilter, OrderFilterResult>
{
    private readonly ShopContext _context;

    public GetOrderByFilterHandler(ShopContext context)
    {
        _context = context;
    }

    public async Task<OrderFilterResult> Handle(GetOrderByFilter request, CancellationToken cancellationToken)
    {
        var @params = request.FilterParams;
        var result =  _context.Orders.OrderByDescending(c => c.CreationDate).AsQueryable();

        if(@params.UserId != null)
           result = result.Where(c => c.UserId == @params.UserId);

        if (@params.Status != null)
            result = result.Where(c => c.Status == @params.Status); 

        if (@params.StartDate != null)
            result = result.Where(c => c.CreationDate <= @params.StartDate);

        if (@params.EndDate != null)
            result = result.Where(c => c.CreationDate >= @params.EndDate);

       
        var skip = (@params.PageId - 1) * @params.Take;
        var model = new OrderFilterResult()
        {
            Data = await result.Skip(skip).Take(@params.Take)
            .Select(order => order.MapFilterData(_context))
           .ToListAsync(cancellationToken),
            FilterParams = @params
        };
        model.GeneratePaging(result, @params.Take, @params.PageId);
        return model;
      
    }

}

