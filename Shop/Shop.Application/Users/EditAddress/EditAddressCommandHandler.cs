using Common.Application;
using Shop.Domain.UserAgg;
using Shop.Domain.UserAgg.Repository;

namespace Shop.Application.Users.EditAddress
{
    public class EditAddressCommandHandler : IBaseCommandHandler<EditAddressCommand>
    {
        private readonly IUserRepository _userRepository;

        public EditAddressCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<OperationResult> Handle(EditAddressCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetTracking(request.UserId);
            if (user == null)
                return OperationResult.NotFound();

            var address = new UserAddress(request.Shire,
                                          request.City,
                                          request.PostalCode,
                                          request.PostalAddress,
                                          request.PhoneNumber,
                                          request.Name,
                                          request.Family,
                                          request.NationalCode);

            user.EditAddress(address, request.Id);
            await _userRepository.Save();

            return OperationResult.Success();
        }
    }
}
