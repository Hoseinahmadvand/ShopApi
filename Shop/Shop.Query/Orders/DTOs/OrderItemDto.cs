using Common.Query;

namespace Shop.Query.Orders.DTOs;

public class OrderItemDto : BaseDto
{
    public long OrderId { get; set; }
    public long InventoryId { get; set; }
    public string ShopName { get; set; }
    public int Price { get; set; }
    public int Count { get; set; }
    public ProductOrderItem Products { get; set; }
    public int TotalPrice => Price * Count;
}
