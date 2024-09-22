using Common.Application;
using Shop.Domain.OrderAgg;
using Shop.Domain.OrderAgg.Repository;

namespace Shop.Application.Orders.CheckOut
{
    public class CheckOutOrderCommandHandler : IBaseCommandHandler<CheckOrderOutCommand>
    {
        private readonly IOrderRepository _orderRepository;
        public async Task<OperationResult> Handle(CheckOrderOutCommand request, CancellationToken cancellationToken)
        {
            var currentOrder = await _orderRepository.GetCurrentUserOrder(request.UserId);
            if (currentOrder == null)
                return OperationResult.NotFound();

            var orderAddress=new OrderAddress(currentOrder.Id,
                                              request.Shire,
                                              request.City,
                                              request.PostalAddress,
                                              request.PostalCode,
                                              request.PhoneNumber,
                                              request.Name,
                                              request.Family,
                                              request.NationalCode);
            currentOrder.Checkout(orderAddress);
            await _orderRepository.Save();
            return OperationResult.Success();
        }
    }
}
