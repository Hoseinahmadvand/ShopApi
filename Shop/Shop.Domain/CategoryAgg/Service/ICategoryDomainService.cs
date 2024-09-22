namespace Shop.Domain.CategoryAgg.Service;

public interface ICategoryDomainService
{
    public bool IsSlugExist(string slug);
}
