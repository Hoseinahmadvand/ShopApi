using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Categories.CategoryMapper;
using Shop.Query.Categories.DTOs;

namespace Shop.Query.Categories.GetById
{
    internal class GetCategorByIdQueryHandler : IQueryHandler<GetCategorByIdQuery, CategoryDto>
    {
        private readonly ShopContext _context;
        public async Task<CategoryDto> Handle(GetCategorByIdQuery request, CancellationToken cancellationToken)
        {
            var model = await _context.Categories.FirstOrDefaultAsync(c => c.Id == request.Id);
            return model.Map();
        }
    }
}
