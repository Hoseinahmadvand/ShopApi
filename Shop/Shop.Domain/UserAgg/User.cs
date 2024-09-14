using Common.Domain;
using Common.Domain.Exceptions;
using Shop.Domain.UserAgg.Enums;
using Shop.Domain.UserAgg.Services;

namespace Shop.Domain.UserAgg
{
    public class User : AggregateRoot
    {


        public string Name { get; private set; }
        public string Family { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public Gender Gender { get; private set; }
        public List<UserRole> Roles { get; private set; }
        public List<Wallet> Wallets { get; private set; }
        public List<UserAddress> Addresses { get; private set; }


        #region User 


        public User(string name,
                 string family,
                 string phoneNumber,
                 string email,
                 string password,
                 Gender gender,
                 IUserDomainService domainService)
        {
            Guard(phoneNumber, email, domainService);
            Name = name;
            Family = family;
            PhoneNumber = phoneNumber;
            Email = email;
            Password = password;
            Gender = gender;
        }

        public void Edit(string name,
                  string family,
                  string phoneNumber,
                  string email,
                  Gender gender,
                  IUserDomainService domainService)
        {
            Guard(phoneNumber, email, domainService);
            Name = name;
            Family = family;
            PhoneNumber = phoneNumber;
            Email = email;
            Gender = gender;
        }

        public static User RegisterUser(string email,
                                        string phoneNumber,
                                        string password,
                                        IUserDomainService domainService)
        {
            return new User("", "", phoneNumber, email, password, Gender.None, domainService);
        }


        public void Guard(string phoneNumber,
                          string email,
                          IUserDomainService domainService)
        {
            NullOrEmptyDomainDataException.CheckString(phoneNumber, nameof(phoneNumber));
            NullOrEmptyDomainDataException.CheckString(email, nameof(email));

            if (phoneNumber.Length != 11)
                throw new InvalidDomainDataException(CommomMassages.NotValid("شماره موبایل"));

            if (email.IsValidEmail() == false)
                throw new InvalidDomainDataException(CommomMassages.NotValid("ایمیل"));

            if (phoneNumber != PhoneNumber)
                if (domainService.IsPhoneNumberExist(phoneNumber))
                    throw new InvalidDomainDataException(CommomMassages.DuplicatedRecord("شماره موبایل"));

            if (email != Email)
                if (domainService.IsEmailExist(email))
                    throw new InvalidDomainDataException(CommomMassages.DuplicatedRecord("ایمیل"));

        }

        #endregion

        #region Address 


        public void AddAdderss(UserAddress address)
        {
            address.UserId = Id;
            Addresses.Add(address);
        }
        public void EditAdderss(UserAddress address)
        {
            var oldAdderss = Addresses.FirstOrDefault(a => a.Id == address.Id);
            if (oldAdderss == null)
                throw new NullOrEmptyDomainDataException(CommomMassages.RecordNotFound("آدرس"));

            Addresses.Remove(oldAdderss);
            Addresses.Add(address);
        }
        public void DeleteAdderss(long addressId)
        {
            var oldAdderss = Addresses.FirstOrDefault(a => a.Id == addressId);
            if (oldAdderss == null)
                throw new NullOrEmptyDomainDataException(CommomMassages.RecordNotFound("آدرس"));

            Addresses.Remove(oldAdderss);

        }

        #endregion

        #region Wallet  

        public void ChargeWallet(Wallet wallet)
        {
            wallet.UserId = Id;
            Wallets.Add(wallet);
        }

        #endregion

        #region Roles 

        public void ChangeRoles(List<UserRole> roles)
        {
            roles.ForEach(r => r.UserId = Id);
            Roles.Clear();
            Roles.AddRange(Roles);
        }

        #endregion



    }
}
