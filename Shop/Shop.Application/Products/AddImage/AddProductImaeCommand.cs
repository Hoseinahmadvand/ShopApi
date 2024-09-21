using Common.Application;
using Microsoft.AspNetCore.Http;

namespace Shop.Application.Products.AddImage
{
    public class AddProductImaeCommand : IBaseCommand
    {
        public AddProductImaeCommand(IFormFile imageFile,
                                     long productId,
                                     int sequence)
        {
            ImageFile = imageFile;
            ProductId = productId;
            Sequence = sequence;
        }

        public IFormFile ImageFile { get; private set; }
        public long ProductId { get; private set; }
        public int Sequence { get; private set; }
    }
}

