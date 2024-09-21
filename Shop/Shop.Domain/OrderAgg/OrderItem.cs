using Common.Domain;
using Common.Domain.Exceptions;

namespace Shop.Domain.OrderAgg
{
    public class OrderItem:BaseEntity
    {
        public OrderItem(long inventoryId,
                         int price,
                         int count)
        {
            PriceGuard(price);
            CountGuard(count);
            InventoryId = inventoryId;
            Price = price;
            Count = count;
        }

        public long OrderId { get; internal set; }
        public long InventoryId { get; private set; }
        public int Price { get; private set; }
        public int Count { get; private set; }
        public int TotalPrice => Price * Count;

        public void IncreaseCount(int count)
        {
            Count += count;
        }
        public void DecreaseCount(int count)
        {
            if (Count == 1)
                return;
            if (Count -count<=0)
                return;
            Count -= count;
        }

        public void ChangeCount(int newCount)
        {

            CountGuard(newCount);
            Count = newCount;
        }

        public void SetPrice(int newPrice)
        {
            PriceGuard(newPrice);
            Price = newPrice;
        }

        #region Guards

        private void PriceGuard(int newPrice)
        {
            if (newPrice < 1)
                throw new InvalidDomainDataException(CommomMassages.NotValid("مبلغ کالا"));
        }

        private void CountGuard(int count)
        {
            if (Count < 1)
                throw new InvalidDomainDataException();
        }

        #endregion

    }
}
