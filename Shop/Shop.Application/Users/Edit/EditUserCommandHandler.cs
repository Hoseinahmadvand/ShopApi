using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Microsoft.AspNetCore.Http;
using Shop.Application._Utilities;
using Shop.Domain.UserAgg.Repository;
using Shop.Domain.UserAgg.Services;

namespace Shop.Application.Users.Edit
{
    internal class EditUserCommandHandler : IBaseCommandHandler<EditUserCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserDomainService _userDomainService;
        private readonly IFileService _fileService;
        public EditUserCommandHandler(IUserDomainService userDomainService, IFileService fileService, IUserRepository userRepository)
        {
            _userDomainService = userDomainService;
            _fileService = fileService;
            _userRepository = userRepository;
        }

        public async Task<OperationResult> Handle(EditUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetTracking(request.UserId);
            if (user == null)
                return OperationResult.NotFound();
            user.Edit(request.Name,
                      request.Family,
                      request.PhoneNumber,
                      request.Email,
                      request.Gender,
                      _userDomainService);
            var oldAvatar =user.Avatar;

            if (request.Avatar != null)
            {
                var imageName = await _fileService.SaveFileAndGenerateName(request.Avatar, Directories.UserAvatarImages);
                user.SetAvatar(imageName);
            }
            DeleteOldAvatar(request.Avatar,oldAvatar);
            await _userRepository.Save();
            return OperationResult.Success();
        }
        private void DeleteOldAvatar(IFormFile? avatarFile,string avatarName)
        {
            if(avatarFile==null||avatarName=="avatar.png")
                return;

            _fileService.DeleteFile(Directories.UserAvatarImages,avatarName);
        }
    }

}
