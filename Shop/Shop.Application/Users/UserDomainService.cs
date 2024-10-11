using Shop.Domain.UserAgg.Repository;
using Shop.Domain.UserAgg.Services;

namespace Shop.Application.Users
{
    public class UserDomainService : IUserDomainService
    {
        private readonly IUserRepository _userRepository;

        public UserDomainService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool IsEmailExist(string email)
        {
            return  _userRepository.Exists(u => u.Email == email);
        }

        public bool IsPhoneNumberExist(string phoneNumber)
        {

            return _userRepository.Exists(u => u.PhoneNumber == phoneNumber);
        }
    }
}
