using Common.Application;
using MediatR;
using Shop.Application.Sellers.Create;
using Shop.Application.Sellers.Edit;
using Shop.Query.Sellers.DTOs;
using Shop.Query.Sellers.GetByFilter;
using Shop.Query.Sellers.GetById;

namespace Shop.Persentation.Facade.Sellers;

internal class SellerFacade : ISellerFacade
{
    private readonly IMediator _mediator;

    public SellerFacade(IMediator mediator)
    {
        _mediator = mediator;
    }

    #region Commands
    public async Task<OperationResult> CreateSeller(CreateSellerCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> EditSeller(EditSellerCommand command)
    {
        return await _mediator.Send(command);

    }
    #endregion

    #region Queries


    public async Task<SellerDto?> GetSellerById(long sellerId)
    {
        return await _mediator.Send(new GetSellerByIdQuery(sellerId));

    }

    public async Task<SellerDto?> GetSellerByUserId(long userId)
    {
        return await _mediator.Send(new GetSellerByIdQuery(userId));
    }

    public async Task<SellerFilterResult> GetSellersByFilter(SellerFilterParams filterParams)
    {
        return await _mediator.Send(new GetSellerByFilterQuery(filterParams));
    }  
    
    #endregion
}