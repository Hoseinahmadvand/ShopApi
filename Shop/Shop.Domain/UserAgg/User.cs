using Common.Domain;
using Common.Domain.Exceptions;
using Common.Domain.ValueObjects;
using Shop.Domain.UserAgg.Enums;
using Shop.Domain.UserAgg.Services;

namespace Shop.Domain.UserAgg;

public class User : AggregateRoot
{
    private User()
    {
        
    }


    public string Name { get; private set; }
    public string Family { get; private set; }
    public string Avatar { get; private set; }
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
             IUserDomainService domainService
            )
    {
        Guard( email, domainService);
        Name = name;
        Family = family;
        PhoneNumber = phoneNumber;
        Email = email;
        Password = password;
        Gender = gender;
        Avatar = "avatar.png";
    }

    public void Edit(string name,
              string family,
              string phoneNumber,
              string email,
              Gender gender,
              IUserDomainService domainService)
    {
        Guard( email, domainService);
        Name = name;
        Family = family;
        PhoneNumber = phoneNumber;
        Email = email;
        Gender = gender;
    }

    public static User RegisterUser(
                                    string phoneNumber,
                                    string password,
                                    IUserDomainService domainService)
    {
        return new User("", "", phoneNumber, null, password, Gender.None, domainService);
    }


    public void SetAvatar(string avatarName)
    {
        if (string.IsNullOrWhiteSpace(avatarName))
            avatarName = "avatar.png";
        Avatar = avatarName;
    }

    #endregion

    #region Address 


    public void AddAdderss(UserAddress address)
    {
        address.UserId = Id;
        Addresses.Add(address);
    }
    public void EditAdderss(UserAddress address,long id)
    {
        var oldAddress = Addresses.FirstOrDefault(f => f.Id == id);
        if (oldAddress == null)
            throw new NullOrEmptyDomainDataException("Address Not found");


        oldAddress.EditAddress(address.Shire,
                               address.City,
                               address.PostalCode,
                               address.PostalAddress,
                               address.PhoneNumber,
                               address.Name,
                               address.Family,
                               address.NationalCode);
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

    #region Guard


    private void Guard( string email,
              IUserDomainService domainService)
    {
        NullOrEmptyDomainDataException.CheckString(email, nameof(email));


        if (email.IsValidEmail() == false)
            throw new InvalidDomainDataException(CommomMassages.NotValid("ایمیل"));


        if (email != Email)
            if (domainService.IsEmailExist(email))
                throw new InvalidDomainDataException(CommomMassages.DuplicatedRecord("ایمیل"));

    }
    #endregion
}
