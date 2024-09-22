using Common.Domain.Repository;

namespace Shop.Domain.SiteEntities.Repository;

public interface IBannerRepository : IBaseRepository<Banner>
{
    void Delete(Banner banner);
}


