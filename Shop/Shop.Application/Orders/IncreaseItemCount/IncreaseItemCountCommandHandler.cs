using Common.Application;
using Shop.Domain.OrderAgg.Repository;

namespace Shop.Application.Orders.IncreaseItemCount
{
    internal class IncreaseItemCountCommandHandler : IBaseCommandHandler<IncreaseItemCountCommand>
    {
        private readonly IOrderRepository _orderRepository;

        public IncreaseItemCountCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<OperationResult> Handle(IncreaseItemCountCommand request, CancellationToken cancellationToken)
        {
            var currentOrder=await _orderRepository.GetCurrentUserOrder(request.UserId);
            if (currentOrder == null)
                return OperationResult.NotFound();

            currentOrder.IncreaseItemCount(request.ItemId, request.Count);
            await _orderRepository.Save();
            return OperationResult.Success();
        }
    }
}
