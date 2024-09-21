using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Shop.Application._Utilities;
using Shop.Domain.ProductAgg;
using Shop.Domain.ProductAgg.Repository;
using Shop.Domain.ProductAgg.Services;

namespace Shop.Application.Products.Create
{
    internal class CreateProductCommandHandler : IBaseCommandHandler<CreateProductCommand>
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductDomainService _productDomainService;
        private readonly IFileService _fileService;

        public CreateProductCommandHandler(IProductRepository productRepository, IProductDomainService productDomainService, IFileService fileService)
        {
            _productRepository = productRepository;
            _productDomainService = productDomainService;
            _fileService = fileService;
        }

        public async Task<OperationResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var image =await _fileService.SaveFileAndGenerateName(request.ImageFile, Directories.ProductImages(request.Title));
            var product=new Product(request.Title,
                                    image,
                                    request.Description,
                                    request.CategoryId,
                                    request.SubCategoryId,
                                    request.SecondarySubCategoryId,
                                    _productDomainService,
                                    request.Slug,
                                    request.SeoData);

            _productRepository.Add(product);

            var specifications=new List<ProductSpecification>();
            request.Specifications.ToList().ForEach(s =>
            {
                specifications.Add(new ProductSpecification(s.Key,s.Value));
            });

            product.SetSpecification(specifications);
        
            await _productRepository.Save();
            return OperationResult.Success();
        }
    }
}
