using Shop.Domain.SellerAgg;
using Shop.Domain.SellerAgg.Repository;
using Shop.Domain.SellerAgg.Services;

namespace Shop.Application.Sellers
{
    public class SellerDomainService : ISellerDomainService
    {
        private readonly ISellerRepository _sellerRepository;

        public SellerDomainService(ISellerRepository sellerRepository)
        {
            _sellerRepository = sellerRepository;
        }

        public bool IsValidSellerInformation(Seller seller)
        {
            var sellerExists = _sellerRepository.Exists(s => s.NationalCode == seller.NationalCode || s.UserId == seller.UserId);
            return !sellerExists;
        }

        public bool NationalCodeExistInDataBase(string nationalCode)
        {
            return _sellerRepository.Exists(s => s.NationalCode == nationalCode);
        }
    }
}
