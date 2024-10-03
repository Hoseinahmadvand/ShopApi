using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Sellers.DTOs;
using Shop.Query.Sellers.Mapper;

namespace Shop.Query.Sellers.GetById;

public class GetSellerByIdQueryHandler : IQueryHandler<GetSellerByIdQuery, SellerDto?>
{
    private readonly ShopContext _context;

    public GetSellerByIdQueryHandler(ShopContext context)
    {
        _context = context;
    }

    public async Task<SellerDto?> Handle(GetSellerByIdQuery request, CancellationToken cancellationToken)
    {
        var seller=await _context.Sellers.FirstOrDefaultAsync(s=>s.Id==request.SellerId,cancellationToken);

        return seller.Map();
    }
}
