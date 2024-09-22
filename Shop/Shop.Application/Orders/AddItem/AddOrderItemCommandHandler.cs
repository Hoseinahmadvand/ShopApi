using Common.Application;
using Shop.Application.Orders.AddItem;
using Shop.Domain.OrderAgg;
using Shop.Domain.OrderAgg.Repository;
using Shop.Domain.SellerAgg.Repository;

internal class AddOrderItemCommandHandler : IBaseCommandHandler<AddOrderItemCommand>
{
    private readonly IOrderRepository _orderRepository;
    private readonly ISellerRepository _sellerRepository;

    public AddOrderItemCommandHandler(IOrderRepository orderRepository, ISellerRepository sellerRepository)
    {
        _orderRepository = orderRepository;
        _sellerRepository = sellerRepository;
    }

    public async Task<OperationResult> Handle(AddOrderItemCommand request, CancellationToken cancellationToken)
    {
        var inventory = await _sellerRepository.GetInventoryBy(request.InventoryId);
        if (inventory == null)
            return OperationResult.NotFound();
        if (inventory.Count < request.Count)
            return OperationResult.Error("تعداد درخواستی ا موجودی انبار بیشتر است .");

        var order = await _orderRepository.GetCurrentUserOrder(request.UserId);
        if (order == null)
            order = new Order(request.UserId);

        if (ItemCountBigerrThanInventoryCount(inventory, order))
            return OperationResult.Error("تعداد درخواستی ا موجودی انبار بیشتر است .");

        order.AddItem(new OrderItem(request.InventoryId,
                                    request.Count,
                                    inventory.Price));
        await _orderRepository.Save();
        return OperationResult.Success();
    }
    private bool ItemCountBigerrThanInventoryCount(InventoryResult inventory, Order order)
    {
        var orderItems = order.Items.First(i => i.InventoryId == inventory.Id);
        if (orderItems.Count > inventory.Count)
            return true;

        return false;
    }
}

