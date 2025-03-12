using Common.Domain.Repository;

namespace Shop.Domain.SiteEntities.Repository;

public interface IShippingMethodRepository : IBaseRepository<ShippingMethod>
{
    void Delete(ShippingMethod method);
}
