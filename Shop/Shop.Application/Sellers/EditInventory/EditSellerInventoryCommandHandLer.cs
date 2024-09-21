using Common.Application;
using Shop.Domain.SellerAgg.Repository;

namespace Shop.Application.Sellers.EditInventory
{
    internal class EditSellerInventoryCommandHandLer : IBaseCommandHandler<EditSellerInventoryCommand>
    {
        private readonly ISellerRepository _repository;

        public EditSellerInventoryCommandHandLer(ISellerRepository repository)
        {
            _repository = repository;
         
        }

        public async Task<OperationResult> Handle(EditSellerInventoryCommand request, CancellationToken cancellationToken)
        {
            var inventory = await _repository.GetTracking(request.InventoryId);
            if (inventory == null)
                return OperationResult.NotFound();
             inventory.EditInventory(request.InventoryId,request.Price,request.Count,request.DiscountPercentage);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
   

}
