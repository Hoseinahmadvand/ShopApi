using Common.Query;
using Shop.Query.SiteEntities.DTOs;

namespace Shop.Query.SiteEntities.Slider.GetById;

public record GetSliderByIdQuery(long SliderId) : IQuery<SliderDto>;
