using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Shop.Domain.ProductAgg.Repository;
using Shop.Domain.ProductAgg.Services;

namespace Shop.Application.Products.Edit
{
    internal class EditProductCommandHandler : IBaseCommandHandler<EditProductCommand>
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductDomainService _productDomainService;
        private readonly IFileService _fileService;

        public EditProductCommandHandler(IProductRepository productRepository, IProductDomainService productDomainService, IFileService fileService)
        {
            _productRepository = productRepository;
            _productDomainService = productDomainService;
            _fileService = fileService;
        }

        public async Task<OperationResult> Handle(EditProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetTracking(request.ProductId);
            if (product == null)
                return OperationResult.NotFound();

            product.Edit(request.Title,
                         request.Description,
                         request.CategoryId,
                         request.SubCategoryId,
                         request.SecondarySubCategoryId,
                         request.Slug,
                         _productDomainService,
                         request.SeoData);

            return OperationResult.Success();
        }
    }
}
