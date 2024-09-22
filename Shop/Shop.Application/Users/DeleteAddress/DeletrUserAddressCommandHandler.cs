using Common.Application;
using Shop.Domain.UserAgg.Repository;

namespace Shop.Application.Users.DeleteAddress
{
    internal class DeletrUserAddressCommandHandler : IBaseCommandHandler<DeletrUserAddressCommand>
    {
        private readonly IUserRepository _userRepository;
        public async Task<OperationResult> Handle(DeletrUserAddressCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetTracking(request.UserId);
            if (user == null)
                return OperationResult.NotFound();

            user.DeleteAdderss(request.AddressId);
            await _userRepository.Save();
            return OperationResult.Success();
        }
    }
}
