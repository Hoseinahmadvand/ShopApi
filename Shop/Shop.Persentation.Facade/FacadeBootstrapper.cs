using Microsoft.Extensions.DependencyInjection;
using Shop.Persentation.Facade.Categories;
using Shop.Persentation.Facade.Comments;
using Shop.Persentation.Facade.Orders;
using Shop.Persentation.Facade.Products;
using Shop.Persentation.Facade.Roles;
using Shop.Persentation.Facade.Sellers.Inventories;
using Shop.Persentation.Facade.Sellers;
using Shop.Persentation.Facade.Siteentities.Banner;
using Shop.Persentation.Facade.Siteentities.Slider;
using Shop.Persentation.Facade.Users.Addresses;
using Shop.Persentation.Facade.Users;
using Shop.Presentation.Facade.Products;
using Shop.Presentation.Facade.Categories;
using Shop.Presentation.Facade.Users;
using Shop.Presentation.Facade.Siteentities.ShippingMethods;

namespace Shop.Persentation.Facade;

public static class FacadeBootstrapper
{
    public static void InitFacadeDependency(this IServiceCollection services)
    {
        services.AddScoped<ICategoryFacade, CategoryFacade>();
        services.AddScoped<ICommentFacade, CommentFacade>();
        services.AddScoped<IOrderFacade, OrderFacade>();
        services.AddScoped<IProductFacade, ProductFacade>();
        services.AddScoped<IRoleFacade, RoleFacade>();
        services.AddScoped<ISellerFacade, SellerFacade>();
        services.AddScoped<IBannerFacade, BannerFacade>();
        services.AddScoped<ISliderFacade, SliderFacade>();
        services.AddScoped<ISellerInventoryFacade, SellerInventoryFacade>();
        services.AddScoped<IShippingMethodFacade, ShippingMethodFacade>();

        services.AddScoped<IUserFacade, UserFacade>();
        services.AddScoped<IUserAddressFacade, UserAddressFacade>();

    }
}
