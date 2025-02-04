﻿using Common.Application;
using MediatR;
using Shop.Application.Categories.AddChild;
using Shop.Application.Categories.Create;
using Shop.Application.Categories.Edit;
using Shop.Application.Categories.Remove;
using Shop.Query.Categories.DTOs;
using Shop.Query.Categories.GetById;
using Shop.Query.Categories.GetByParentId;
using Shop.Query.Categories.GetList;

namespace Shop.Persentation.Facade.Categories;

internal class CategoryFacade : ICategoryFacade
{
    private readonly IMediator _mediator;

    public CategoryFacade(IMediator mediator)
    {
        _mediator = mediator;
    }

    #region Commands
    public async Task<OperationResult<long>> Create(CreateCategoryCommand command)
    {
        // await _cache.RemoveAsync(CacheKeys.Categories);
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> Edit(EditCategoryCommand command)
    {
        return await _mediator.Send(command);
    }
    async Task<OperationResult<long>> ICategoryFacade.AddChild(AddChildCategoryCommand command)
    {
        return await _mediator.Send(command);
    }
    #endregion

    #region Queries
    public async Task<List<CategoryDto>> GetCategories()
    {
        return await _mediator.Send(new GetCategoryList());
    }

    public async Task<List<ChildCategoryDto>> GetCategoriesByParentId(long parentId)
    {
        return await _mediator.Send(new GetCategoryByParentIdQuery(parentId));
    }

    public async Task<CategoryDto> GetCategoryById(long id)
    {
        return await _mediator.Send(new GetCategoryByIdQuery(id));
    }

    public async Task<OperationResult> Remove(long categoryId)
    {
        return await _mediator.Send(new RemoveCategoryCommand(categoryId));
    }

    #endregion
}