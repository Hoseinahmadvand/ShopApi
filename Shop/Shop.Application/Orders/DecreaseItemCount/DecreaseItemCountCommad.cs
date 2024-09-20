using Common.Application;

namespace Shop.Application.Orders.DecreaseItemCount
{
    public record DecreaseItemCountCommad(long UserId, long ItemId, int Count) : IBaseCommand;
}
