using Common.Application;

namespace Shop.Application.Users.DeleteAddress
{
    public record DeletrUserAddressCommand(long UserId, long AddressId) : IBaseCommand;
}
