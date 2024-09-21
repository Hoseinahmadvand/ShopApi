using Common.Application;
using Common.Domain.ValueObjects;

namespace Shop.Application.Users.AddAddress
{
    public class AddAddressCommand : IBaseCommand
    {
        public AddAddressCommand(long userId,
            string shire,
                                 string city,
                                 string postalCode,
                                 string postalAddress,
                                 PhoneNumber phoneNumber,
                                 string name,
                                 string family,
                                 string nationalCode)
        {
            Shire = shire;
            City = city;
            PostalCode = postalCode;
            PostalAddress = postalAddress;
            PhoneNumber = phoneNumber;
            Name = name;
            Family = family;
            NationalCode = nationalCode;
            UserId = userId;
        }

        public long UserId { get;private set; }
        public string Shire { get; private set; }
        public string City { get; private set; }
        public string PostalCode { get; private set; }
        public string PostalAddress { get; private set; }
        //Resiver
        public PhoneNumber PhoneNumber { get; private set; }
        public string Name { get; private set; }
        public string Family { get; private set; }
        public string NationalCode { get; private set; }
    }
}
