using Common.Application;
using Shop.Domain.UserAgg;
using Shop.Domain.UserAgg.Repository;

namespace Shop.Application.Users.AddAddress
{
    internal class AddAddressCommandHandler : IBaseCommandHandler<AddAddressCommand>
    {
        private readonly IUserRepository _userRepository;

        public AddAddressCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<OperationResult> Handle(AddAddressCommand request, CancellationToken cancellationToken)
        {
            var user =await _userRepository.GetTracking(request.UserId);
            if (user == null)
                return OperationResult.NotFound();

            var address = new UserAddress(request.Shire, request.City, request.PostalCode, request.PostalAddress, request.PhoneNumber, request.Name, request.Family, request.NationalCode);

            user.AddAdderss(address);
            await _userRepository.Save();
            return OperationResult.Success();
        }
    }
}
