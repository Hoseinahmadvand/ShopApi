using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Shop.Application._Utilities;
using Shop.Domain.SiteEntities;
using Shop.Domain.SiteEntities.Repository;

namespace Shop.Application.SiteEntities.Sliders.Create
{
    internal class CreateSliderCommandHandler : IBaseCommandHandler<CreateSliderCommand>
    {
        private readonly ISliderRepository _sliderRepository;
        private readonly IFileService _fileService;
        public CreateSliderCommandHandler(ISliderRepository sliderRepository, IFileService fileService)
        {
            _sliderRepository = sliderRepository;
            _fileService = fileService;
        }

        public async Task<OperationResult> Handle(CreateSliderCommand request, CancellationToken cancellationToken)
        {
            var imageName = await _fileService.SaveFileAndGenerateName(request.ImageFile, Directories.SliderImages);

            var slider = new Slider(request.Title, request.Link, imageName);
            _sliderRepository.Add(slider);
            await _sliderRepository.Save();
            return OperationResult.Success();
        }

    }
}
