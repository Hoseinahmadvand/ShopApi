using Common.Application;

namespace Shop.Application.Orders.RemoveItem
{
    public record RemoveItemCommand(long UserId, long ItemId) : IBaseCommand;
}
