using Common.Domain;

namespace Shop.Domain.OrderAgg.ValueObjects
{
    public class ShippingMethod : ValueObject
    {
        public ShippingMethod(int shippingPrice, string shippingType)
        {
            ShippingPrice = shippingPrice;
            ShippingType = shippingType;
        }

        public int ShippingCost { get; private set; }
        public string ShippingType { get; private set; }
    }
}
