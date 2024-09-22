using Common.Domain.Repository;

namespace Shop.Domain.SiteEntities.Repository;

public interface ISliderRepository : IBaseRepository<Slider>
{
    void Delete(Slider slider);
}
