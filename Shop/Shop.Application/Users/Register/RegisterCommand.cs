using Common.Application;
using Common.Domain.ValueObjects;

namespace Shop.Application.Users.Register
{
    public class RegisterCommand:IBaseCommand
    {
        public RegisterCommand(string phoneNumber, string password)
        {
            PhoneNumber = phoneNumber;
            Password = password;
        }

        public string  PhoneNumber { get; set; }
        public string Password { get; set; }
    }
}
