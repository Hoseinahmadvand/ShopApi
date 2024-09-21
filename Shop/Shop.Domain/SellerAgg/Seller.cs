using Common.Domain;
using Common.Domain.Exceptions;
using Shop.Domain.SellerAgg.Enums;
using Shop.Domain.SellerAgg.Services;

namespace Shop.Domain.SellerAgg
{
    public class Seller : AggregateRoot
    {
        public long UserId { get; private set; }
        public string ShopName { get; private set; }
        public string NationalCode { get; private set; }
        public SellerStatus Status { get; private set; }
        public DateTime? LastUpdate { get; private set; }
        public List<SellerInventory> Inventories { get; private set; }

        private Seller()
        {
        }

        #region Seller

        public Seller(long userId, string shopName, string nationalCode, ISellerDomainService domainService)
        {
            Guard(shopName, nationalCode);
            UserId = userId;
            ShopName = shopName;
            NationalCode = nationalCode;
            Inventories = new List<SellerInventory>();

            if (domainService.IsValidSellerInformation(this) == false)
                throw new InvalidDomainDataException(CommomMassages.NotValid("اطلاعات"));

        }

        public void ChangeStatus(SellerStatus status)
        {
            Status = status;
            LastUpdate = DateTime.Now;
        }

        public void Edit(string shopName, string nationalCode, SellerStatus status, ISellerDomainService domainService)
        {
            Guard(shopName, nationalCode);
            if (nationalCode != NationalCode)
                if (domainService.NationalCodeExistInDataBase(nationalCode))
                    throw new InvalidDomainDataException(CommomMassages.DuplicatedRecord("کدملی"));

            ShopName = shopName;
            NationalCode = nationalCode;
            Status = status;
        }
#endregion

        #region Inventory


        public void AddInventory(SellerInventory inventory)
        {
            if (Inventories.Any(f => f.ProductId == inventory.ProductId))
                throw new InvalidDomainDataException(CommomMassages.DuplicatedRecord("محصول"));

            Inventories.Add(inventory);
        }

        public void EditInventory(long inventoryId, int count, int price, int? discountPercentage)
        {
            var currentInventory = Inventories.FirstOrDefault(f => f.Id == inventoryId);
            if (currentInventory == null)
                throw new NullOrEmptyDomainDataException(CommomMassages.RecordNotFound("محصول"));

            //TODO Check Inventories
            currentInventory.Edit(count, price, discountPercentage);
        }
        #endregion

        #region Guard
        private void Guard(string shopName, string nationalCode)
        {
            NullOrEmptyDomainDataException.CheckString(shopName, nameof(shopName));
            NullOrEmptyDomainDataException.CheckString(nationalCode, nameof(nationalCode));
            if (IranianNationalIdChecker.IsValid(nationalCode) == false)
                throw new InvalidDomainDataException(CommomMassages.NotValid("کدملی"));
        }

        #endregion
    }
}
