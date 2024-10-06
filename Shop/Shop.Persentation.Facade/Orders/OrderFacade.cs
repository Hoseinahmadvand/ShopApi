using Common.Application;
using MediatR;
using Shop.Application.Orders.AddItem;
using Shop.Application.Orders.CheckOut;
using Shop.Application.Orders.DecreaseItemCount;
using Shop.Application.Orders.RemoveItem;
using Shop.Query.Orders.DTOs;
using Shop.Query.Orders.GetByFilter;
using Shop.Query.Orders.GetById;

namespace Shop.Persentation.Facade.Orders;

internal class OrderFacade : IOrderFacade
{
    private readonly IMediator _mediator;

    public OrderFacade(IMediator mediator)
    {
        _mediator = mediator;
    }

    #region Commands

  
    public async Task<OperationResult> AddOrderItem(AddOrderItemCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> DecreaseItemCount(DecreaseOrderItemCountCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> OrderCheckOut(CheckOutOrderCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> RemoveOrderItem(RemoveOrderItemCommand command)
    {
        return await _mediator.Send(command);
    }

   public async Task<OperationResult> IncreaseItemCount(DecreaseOrderItemCountCommand command)
    {
       return await _mediator.Send(command);
    }


    #endregion


    #region Queries
    public async Task<OrderDto?> GetOrderById(long orderId)
    {
        return await _mediator.Send(new GetOrderByIdQuery(orderId));
    }

    public async Task<OrderFilterResult> GetOrdersByFilter(OrderFilterParams filterParams)
    {
        return await _mediator.Send(new GetOrdersByFilterQuery(filterParams));
    }

    public Task<OperationResult> SendOrder(long orderId)
    {
        throw new NotImplementedException();
    }

    public Task<OrderDto?> GetCurrentOrder(long userId)
    {
        throw new NotImplementedException();
    }

    #endregion
}
