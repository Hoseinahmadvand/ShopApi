using Common.Application;
using Shop.Application.Users.AddAddress;
using Shop.Application.Users.DeleteAddress;
using Shop.Application.Users.EditAddress;
using Shop.Application.Users.SetActiveAddress;
using Shop.Query.Users.DTOs;

namespace Shop.Persentation.Facade.Users.Addresses;

public interface IUserAddressFacade
{
    Task<OperationResult> AddAddress(AddAddressCommand command);

    Task<OperationResult> EditAddress(EditAddressCommand command);
    Task<OperationResult> DeleteAddress(DeleteUserAddressCommand command);

    Task<AddressDto?> GetById(long userAddressId);
    Task<List<AddressDto>> GetList(long userId);
    Task<OperationResult> SetActiveAddress(SetActiveUserAddressCommand command);
}
