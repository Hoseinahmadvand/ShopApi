using Shop.Domain.CategoryAgg;
using Shop.Query.Categories.DTOs;

namespace Shop.Query.Categories.CategoryMapper;

internal static class CategoryMapper
{
    internal static CategoryDto Map(this Category category)
    {
        if (category == null)
            return null;

        return new CategoryDto()
        {
            Title = category.Title,
            Slug = category.Slug,
            Id = category.Id,
            SeoData = category.SeoData,
            CreationDate = category.CreationDate,

            Childs = category.Childs.MapChildern()
        };
    }
    internal static List<ChildCategoryDto> MapChildern(this List<Category> childern)
    {
        var model = new List<ChildCategoryDto>();
        childern.ForEach(c =>
        {
            model.Add(new ChildCategoryDto()
            {
                Title = c.Title,
                Slug = c.Slug,
                Id = c.Id,
                SeoData = c.SeoData,
                CreationDate = c.CreationDate,
                ParentId = (long)c.ParentId,
                Childs=c.Childs.MapSecondaryChildern()
            });
        });
        return model;
    }
    internal static List<SecondaryChildCategoryDto> MapSecondaryChildern(this List<Category> secondaryChildern)
    {
        var model = new List<SecondaryChildCategoryDto>();
        secondaryChildern.ForEach(c =>
        {
            model.Add(new SecondaryChildCategoryDto()
            {
                Title = c.Title,
                Slug = c.Slug,
                Id = c.Id,
                SeoData = c.SeoData,
                CreationDate = c.CreationDate,
                ParentId = (long)c.ParentId
            });
        });
        return model;
    }
}
