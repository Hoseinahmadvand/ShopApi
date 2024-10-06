using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Shop.Application._Utilities;
using Shop.Application.Categories;
using Shop.Application.Products;
using Shop.Application.Sellers;
using Shop.Application.Users;
using Shop.Domain.CategoryAgg.Service;
using Shop.Domain.ProductAgg.Services;
using Shop.Domain.SellerAgg.Services;
using Shop.Domain.UserAgg.Services;
using Shop.Infrastructure;
using Shop.Persentation.Facade;
using Shop.Query.Categories.GetById;

namespace Shop.Config;

public static class ShopBootstraper
{
    public static void Configure(this IServiceCollection services, string connectionString)
    {
        InfrastructureBootstrapper.Init(services, connectionString);

        var assemblies = new[]
        {
            typeof(Directories).Assembly,
            typeof(GetCategoryByIdQuery).Assembly
        };
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assemblies));

        services.AddTransient<IProductDomainService, ProductDomainService>();
        services.AddTransient<IUserDomainService, UserDomainService>();
        services.AddTransient<ICategoryDomainService, CategoryDomainService>();
        services.AddTransient<ISellerDomainService, SellerDomainService>();


        //services.AddValidatorsFromAssembly(typeof(CreateRoleCommandValidator).Assembly);

        services.InitFacadeDependency();
    }
}
