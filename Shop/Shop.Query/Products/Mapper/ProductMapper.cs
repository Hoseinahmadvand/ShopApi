using Microsoft.EntityFrameworkCore;
using Shop.Domain.ProductAgg;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Products.DTOs;

namespace Shop.Query.Products.Mapper;

public static class ProductMapper
{
    public static ProductDto? Map(this Product? product)
    {
        if (product == null)
            return null;

        return new ProductDto()
        {
            Id = product.Id,
            Title = product.Title,
            ImageName = product.ImageName,
            Description = product.Description,
            Slug = product.Slug,
            SeoData = product.SeoData,
            Specifications = product.Specifications.Select(s => new ProductSpecificationDto()
            {
                Value = s.Value,
                Key = s.Key
            }).ToList(),
            Images = product.Images.Select(product => new ProductImageDto()
            {
                Id = product.Id,
                ImageName = product.ImageName,
                CreationDate = product.CreationDate,
                ProductId = product.Id,
                Sequence = product.Sequence
            }).ToList(),
            Category = new()
            {
                Id = product.CategoryId
            },
            SubCategory = new()
            {
                Id = product.SubCategoryId
            },
            SecondarySubCategory = product.SecondarySubCategoryId != null ? new()
            {
                Id = (long)product.SecondarySubCategoryId
            } : null,
        };

    }

    public static ProductFilterData MapListData(this Product product)
    {
        return new ProductFilterData()
        {
            Id = product.Id,
            Title = product.Title,
            ImageName = product.ImageName,
            Slug = product.Slug,
            CreationDate = product.CreationDate
        };

    }

    public static async Task SetCategories(this ProductDto product, ShopContext context)
    {
        var categories = await context.Categories
           .Where(r => r.Id == product.Category.Id || r.Id == product.SubCategory.Id)
           .Select(s => new ProductCategoryDto()
           {
               Id = s.Id,
               Slug = s.Slug,
               ParentId = s.ParentId,
               SeoData = s.SeoData,
               Title = s.Title
           }).ToListAsync();

        if (product.SecondarySubCategory != null)
        {
            var secondarySubCategory = await context.Categories
                .Where(f => f.Id == product.SecondarySubCategory.Id)
                .Select(s => new ProductCategoryDto()
                {
                    Id = s.Id,
                    Slug = s.Slug,
                    ParentId = s.ParentId,
                    SeoData = s.SeoData,
                    Title = s.Title
                })
                .FirstOrDefaultAsync();

            if (secondarySubCategory != null)
                product.SecondarySubCategory = secondarySubCategory;
        }
        product.Category = categories.First(r => r.Id == product.Category.Id);
        product.SubCategory = categories.First(r => r.Id == product.SubCategory.Id);
    }

}

