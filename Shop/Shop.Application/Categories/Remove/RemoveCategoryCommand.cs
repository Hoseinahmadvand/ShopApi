using Common.Application;
using Shop.Domain.CategoryAgg.Repository;

namespace Shop.Application.Categories.Remove;

public record RemoveCategoryCommand(long Id) : IBaseCommand;
internal class RemoveCategoryCommandHandler : IBaseCommandHandler<RemoveCategoryCommand>
{
    private readonly ICategoryRepository _categoryRepository;

    public RemoveCategoryCommandHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<OperationResult> Handle(RemoveCategoryCommand request, CancellationToken cancellationToken)
    {
       var result =await _categoryRepository.DeleteCategory(request.Id);
        if (result)
            return OperationResult.Success();
        else
            return OperationResult.Error("امکان حذف این دسته بندی وجود ندارد");
    }
}


