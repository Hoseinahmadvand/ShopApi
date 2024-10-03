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
        var category = await context
            .Categories
            .Where(c => c.Id == product.Category.Id)
            .Select(c => new ProductCategoryDto()
            {
                Id = c.Id,
                Title = c.Title,
                SeoData = c.SeoData,
                Slug = c.Slug,
                ParentId = c.ParentId
            })
            .FirstOrDefaultAsync();

        if (category != null)
            product.Category = category;



        var subCategory = await context
            .Categories
            .Where(c => c.Id == product.SubCategory.Id)
            .Select(c => new ProductCategoryDto()
            {
                Id = c.Id,
                Title = c.Title,
                SeoData = c.SeoData,
                Slug = c.Slug,
                ParentId = c.ParentId
            }).FirstOrDefaultAsync();

        if (subCategory != null)
            product.SubCategory = subCategory;




        if (product.SecondarySubCategory != null)
        {
            var secodarySubCategory = await context
            .Categories
             .Where(c => c.Id == product.SecondarySubCategory.Id)
            .Select(c => new ProductCategoryDto()
            {
                Id = c.Id,
                Title = c.Title,
                SeoData = c.SeoData,
                Slug = c.Slug,
                ParentId = c.ParentId
            })
            .FirstOrDefaultAsync();

            if (secodarySubCategory != null)
                product.SecondarySubCategory = secodarySubCategory;
        }

    }
}
