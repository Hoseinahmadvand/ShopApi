using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Shop.Application._Utilities;
using Shop.Domain.ProductAgg;
using Shop.Domain.ProductAgg.Repository;

namespace Shop.Application.Products.AddImage
{
    internal class AddProductImaeCommandHandler : IBaseCommandHandler<AddProductImaeCommand>
    {
        private readonly IProductRepository _productRepository;
        private readonly IFileService _fileService;

        public AddProductImaeCommandHandler(IProductRepository productRepository, IFileService fileService)
        {
            _productRepository = productRepository;
            _fileService = fileService;
        }

        public async Task<OperationResult> Handle(AddProductImaeCommand request, CancellationToken cancellationToken)
        {
            var product=await _productRepository.GetTracking(request.ProductId);
            if (product == null)
                return OperationResult.NotFound();
           var imagName=await _fileService.SaveFileAndGenerateName(request.ImageFile,Directories.ProductImaesGallery(product.ImageName));

            var image = new ProductImage(imagName, request.Sequence);
            product.AddImage(image);

            await _productRepository.Save();
            return OperationResult.Success();
        }
    }
}

