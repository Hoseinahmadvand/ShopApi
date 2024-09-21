using Common.Application;

namespace Shop.Application.Products.RemoveImage
{ 
    public record RemoveProductImaeCommand(long ProductId,
                                           long ImageId) : IBaseCommand;

}