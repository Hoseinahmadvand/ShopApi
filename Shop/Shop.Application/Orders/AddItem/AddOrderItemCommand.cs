using Common.Application;
using Shop.Application.Orders.AddItem;

namespace Shop.Application.Orders.AddItem
{
    public class AddOrderItemCommand : IBaseCommand
    {
        public AddOrderItemCommand(int count, long inventoryId, long userId)
        {
            Count = count;
            InventoryId = inventoryId;
            UserId = userId;
        }

        public int Count { get; private set; }
        public long InventoryId { get; private set; }
        public long UserId { get; private set; }
    }
}

