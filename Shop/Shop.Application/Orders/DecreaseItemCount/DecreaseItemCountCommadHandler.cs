using Common.Application;
using Shop.Domain.OrderAgg.Repository;

namespace Shop.Application.Orders.DecreaseItemCount
{
    public class DecreaseItemCountCommadHandler : IBaseCommandHandler<DecreaseItemCountCommad>
    {
        private readonly IOrderRepository _orderRepository;

        public DecreaseItemCountCommadHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<OperationResult> Handle(DecreaseItemCountCommad request, CancellationToken cancellationToken)
        {
            var currentOrder = await _orderRepository.GetCuurentUserOrder(request.UserId);
            if (currentOrder == null)
                return OperationResult.NotFound();

            currentOrder.DecreaseItemCount(request.ItemId, request.Count);
            await _orderRepository.Save();
            return OperationResult.Success();
        }
    }
}
