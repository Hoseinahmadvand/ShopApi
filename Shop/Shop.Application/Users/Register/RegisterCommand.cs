using Common.Application;
using Common.Domain.ValueObjects;

namespace Shop.Application.Users.Register
{
    public class RegisterCommand:IBaseCommand
    {
        public RegisterCommand(PhoneNumber phoneNumber, string password)
        {
            PhoneNumber = phoneNumber;
            Password = password;
        }

        public PhoneNumber  PhoneNumber { get; set; }
        public string Password { get; set; }
    }
}
