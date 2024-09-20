using Common.Application;
using Shop.Domain.OrderAgg.Repository;

namespace Shop.Application.Orders.RemoveItem
{
    public class RemoveItemCommandHamdler : IBaseCommandHandler<RemoveItemCommand>
    {
        private readonly IOrderRepository _orderRepository;

        public RemoveItemCommandHamdler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<OperationResult> Handle(RemoveItemCommand request, CancellationToken cancellationToken)
        {
            var currentOrder = await _orderRepository.GetCuurentUserOrder(request.UserId);
            if (currentOrder == null)
                return OperationResult.NotFound();

            currentOrder.RemoveItem(request.ItemId);
            await _orderRepository.Save();
            return OperationResult.Success();
        }
    }
}
