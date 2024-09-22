using Common.Domain;

namespace Shop.Domain.OrderAgg.ValueObjects;

public class OrderShippingMethod : ValueObject
{
    public OrderShippingMethod(int shippingPrice, string shippingType)
    {
        ShippingCost = shippingPrice;
        ShippingType = shippingType;
    }

    public int ShippingCost { get; private set; }
    public string ShippingType { get; private set; }
}
