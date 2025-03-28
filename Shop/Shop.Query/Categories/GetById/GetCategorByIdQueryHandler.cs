﻿using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Categories.DTOs;
using Shop.Query.Categories.Mapper;

namespace Shop.Query.Categories.GetById
{
    internal class GetCategorByIdQueryHandler : IQueryHandler<GetCategoryByIdQuery, CategoryDto>
    {
        private readonly ShopContext _context;

        public GetCategorByIdQueryHandler(ShopContext context)
        {
            _context = context;
        }

        public async Task<CategoryDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var model = await _context.Categories.FirstOrDefaultAsync(c => c.Id == request.Id);
            return model.Map();
        }
    }
}
