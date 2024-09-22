using Common.Domain;
using Common.Domain.Exceptions;
using Shop.Domain.OrderAgg.Enums;
using Shop.Domain.OrderAgg.ValueObjects;

namespace Shop.Domain.OrderAgg;

public class Order : AggregateRoot
{
    #region Ctor


    private Order()
    {

    }
    public Order(long userId)
    {
        UserId = userId;
        Status = OrderStatus.Pennding;
        Items = new List<OrderItem>();
    }

    #endregion


    public long UserId { get; private set; }
    public OrderStatus Status { get; private set; }
    public OrderDiscount? Discount { get; private set; }
    public OrderAddress? Address { get; private set; }
    public OrderShippingMethod? ShippingMethod { get; private set; }
    public List<OrderItem> Items { get; private set; }
    public DateTime? LastUpdate { get; set; }
    public int TotalPrice
    {
        get
        {
            var totalPrice = Items.Sum(i => i.TotalPrice);
            if (ShippingMethod != null)
                totalPrice += ShippingMethod.ShippingCost;
            if (Discount != null)
                totalPrice -= Discount.DiscountAmount;
            return totalPrice;
        }
    }
    public int ItemCount => Items.Count;


    #region Items 


    public void AddItem(OrderItem item)
    {
        ChangeOrderGuard();
        var oldItem = Items.FirstOrDefault(i => i.Id == item.InventoryId);
        if (oldItem != null)
        {
            oldItem.ChangeCount(item.Count + oldItem.Count);
            return;
        }
        Items.Add(item);
    }
    public void RemoveItem(long itemId)
    {
        ChangeOrderGuard();
        var currentItem = Items.FirstOrDefault(i => i.Id == itemId);
        if (currentItem != null)
            Items.Remove(currentItem);
    }

    public void ChaneCountItem(long itemId, int count)
    {
        ChangeOrderGuard();
        var currentItem = Items.FirstOrDefault(i => i.Id == itemId);
        if (currentItem == null)
            throw new NullOrEmptyDomainDataException();

        currentItem.ChangeCount(count);
    }
    public void IncreaseItemCount(long itemId,int count)
    {
        ChangeOrderGuard();
        var currentItem = Items.FirstOrDefault(i => i.Id == itemId);

        if (currentItem == null)
            throw new NullOrEmptyDomainDataException();

        currentItem.IncreaseCount(count);
    }
    public void DecreaseItemCount(long itemId,int count)
    {
        ChangeOrderGuard();
        var currentItem = Items.FirstOrDefault(i => i.Id == itemId);

        if (currentItem == null)
            throw new NullOrEmptyDomainDataException();

        currentItem.DecreaseCount(count);
    }

    #endregion

    #region Status


    public void ChangeStatus(OrderStatus status)
    {
        Status = status;
        LastUpdate = DateTime.Now;
    }


    #endregion

    #region Address


    public void Checkout(OrderAddress orderAddress)
    {
        ChangeOrderGuard();
        Address = orderAddress;
    }

    #endregion

    private void ChangeOrderGuard()
    {
        if (Status != OrderStatus.Pennding)
            throw new InvalidDomainDataException("امکان ویرایش این سفارش وجود ندارد .");

    }
}
