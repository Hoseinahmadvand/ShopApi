using Common.Application;
using Shop.Application.SiteEntities.Banners.Create;
using Shop.Application.SiteEntities.Banners.Edit;
using Shop.Query.SiteEntities.DTOs;

namespace Shop.Persentation.Facade.Siteentities.Banner;


public interface IBannerFacade
{
    Task<OperationResult> CreateBanner(CreateBannerCommand command);
    Task<OperationResult> EditBanner(EditBannerCommand command);
    Task<OperationResult> DeleteBanner(long bannerId);

    Task<BannerDto?> GetBannerById(long id);
    Task<List<BannerDto>> GetBanners();
}
