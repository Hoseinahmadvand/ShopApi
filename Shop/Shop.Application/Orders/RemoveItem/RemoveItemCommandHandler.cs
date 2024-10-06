using Common.Application;
using Shop.Domain.OrderAgg.Repository;

namespace Shop.Application.Orders.RemoveItem
{
    internal class RemoveItemCommandHandler : IBaseCommandHandler<RemoveOrderItemCommand>
    {
        private readonly IOrderRepository _orderRepository;

        public RemoveItemCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<OperationResult> Handle(RemoveOrderItemCommand request, CancellationToken cancellationToken)
        {
            var currentOrder = await _orderRepository.GetCurrentUserOrder(request.UserId);
            if (currentOrder == null)
                return OperationResult.NotFound();

            currentOrder.RemoveItem(request.ItemId);
            await _orderRepository.Save();
            return OperationResult.Success();
        }
    }
}
