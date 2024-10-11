using Shop.Domain.CategoryAgg.Repository;
using Shop.Domain.CategoryAgg.Service;

namespace Shop.Application.Categories;

public class CategoryDomainService : ICategoryDomainService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryDomainService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public bool IsSlugExist(string slug)
    {
        return _categoryRepository.Exists(c=>c.Slug == slug);
    }
}
