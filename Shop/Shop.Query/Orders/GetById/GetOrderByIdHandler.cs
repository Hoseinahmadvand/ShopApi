using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Dapper;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Orders.DTOs;
using Shop.Query.Orders.Mapper;

namespace Shop.Query.Orders.GetById;

internal class GetOrderByIdHandler : IQueryHandler<GetOrderById, OrderDto?>
{
    private readonly ShopContext _context;
    private readonly DapperContext _dapperContext;

    public GetOrderByIdHandler(ShopContext context, DapperContext dapperContext)
    {
        _context = context;
        _dapperContext = dapperContext;
    }

    public async Task<OrderDto?> Handle(GetOrderById request, CancellationToken cancellationToken)
    {
        var order = await _context.Orders.FirstOrDefaultAsync(c => c.Id == request.OrderId, cancellationToken);
        var orderDto = order.Map();


        orderDto.FullName = await _context.Users
                .Where(u => u.Id == orderDto.UserId)
                .Select(u => $"{u.Name} {u.Family}")
                .FirstAsync(cancellationToken);
        orderDto.Items = await orderDto.GetOrderItems(_dapperContext);

        return orderDto;

    }
}
