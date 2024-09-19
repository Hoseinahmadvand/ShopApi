using Common.Application;
using Shop.Domain.CategoryAgg;
using Shop.Domain.CategoryAgg.Repository;
using Shop.Domain.CategoryAgg.Service;

namespace Shop.Application.Categories.AddChild
{
    public class AddChildCategoryCommandHandler : IBaseCommandHandler<AddChildCategoryCommand>
    {
        private readonly ICategoryRepository _repository;
        private readonly ICategoryDomainService _domainService;

        public AddChildCategoryCommandHandler(ICategoryRepository repository, ICategoryDomainService domainService)
        {
            _repository = repository;
            _domainService = domainService;
        }

        public async Task<OperationResult> Handle(AddChildCategoryCommand request, CancellationToken cancellationToken)
        {
            var parentCategory =await _repository.GetTracking(request.ParentId);
            if (parentCategory == null)
                return OperationResult.NotFound();

            var childCategory=new Category(request.Title,
                                           request.Slug,
                                           request.SeoData,
                                           _domainService);

            _repository.Add(childCategory);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
