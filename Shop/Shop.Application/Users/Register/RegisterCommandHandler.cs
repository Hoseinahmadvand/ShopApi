using Common.Application;
using Common.Application.SecurityUtil;
using Shop.Domain.UserAgg;
using Shop.Domain.UserAgg.Repository;
using Shop.Domain.UserAgg.Services;

namespace Shop.Application.Users.Register
{
    public class RegisterCommandHandler : IBaseCommandHandler<RegisterCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserDomainService _userDomainService;

        public RegisterCommandHandler(IUserRepository userRepository, IUserDomainService userDomainService)
        {
            _userRepository = userRepository;
            _userDomainService = userDomainService;
        }

        public async Task<OperationResult> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var user = User.RegisterUser(request.PhoneNumber.Value, Sha256Hasher.Hash(request.Password), _userDomainService);
            _userRepository.Add(user);
            await _userRepository.Save();
            return OperationResult.Success();
        }
    }
}
