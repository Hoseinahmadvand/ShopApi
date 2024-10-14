using Common.Application;
using MediatR;
using Shop.Application.Products.AddImage;
using Shop.Application.Products.Create;
using Shop.Application.Products.Edit;
using Shop.Application.Products.RemoveImage;
using Shop.Persentation.Facade.Sellers.Inventories;
using Shop.Query.Products.DTOs;
using Shop.Query.Products.GetByFilter;
using Shop.Query.Products.GetById;
using Shop.Query.Products.GetBySlug;
using Shop.Query.Products.GetForShop;
namespace Shop.Persentation.Facade.Products;


internal class ProductFacade : IProductFacade
{
    private readonly IMediator _mediator;
    private readonly ISellerInventoryFacade _inventoryFacade;
    public ProductFacade(IMediator mediator, ISellerInventoryFacade inventoryFacade)
    {
        _mediator = mediator;
        _inventoryFacade = inventoryFacade;
    }

    #region Commands

    public async Task<OperationResult> AddImage(AddProductImageCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> CreateProduct(CreateProductCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> EditProduct(EditProductCommand command)
    {
        return await _mediator.Send(command);
    }
    public async Task<OperationResult> RemoveImage(RemoveProductImageCommand command)
    {
        return await _mediator.Send(command);
    }
    #endregion


    #region Queries


    public async Task<ProductDto?> GetProductById(long productId)
    {
        return await _mediator.Send(new GetProductByIdQuery(productId));
    }

    public async Task<ProductDto?> GetProductBySlug(string slug)
    {
        return await _mediator.Send(new GetProductBySlugQuery(slug));
    }

    public async Task<ProductFilterResult> GetProductsByFilter(ProductFilterParams filterParams)
    {
        return await _mediator.Send(new GetProductByFilterQuery(filterParams));
    }

    public Task<SingleProductDto?> GetProductBySlugForSinglePage(string slug)
    {
        throw new NotImplementedException();
        //return await _cache.GetOrSet(CacheKeys.Product(slug), async () =>
        //{
        //    var product = await _mediator.Send(new GetProductBySlugQuery(slug));
        //    if (product == null)
        //        return null;

        //    var inventories = await _inventoryFacade.GetByProductId(product.Id);
        //    var model = new SingleProductDto()
        //    {
        //        Inventories = inventories,
        //        ProductDto = product
        //    };
        //    return model;
        //});
    }

    public async Task<ProductShopResult> GetProductsForShop(ProductShopFilterParam filterParams)
    {
        return await _mediator.Send(new GetProductsForShopQuery(filterParams));
    }


    #endregion

}