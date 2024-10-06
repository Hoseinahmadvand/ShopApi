using Common.Application;
using Shop.Application.Users.Create;
using Shop.Application.Users.Edit;
using Shop.Domain.UserAgg;
using Shop.Query.Users.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Shop.Persentation.Facade.Users;

public interface IUserFacade
{
  //  Task<OperationResult> RegisterUser(RegisterUserCommand command);
    Task<OperationResult> EditUser(EditUserCommand command);
    Task<OperationResult> CreateUser(CreateUserCommand command);
  //  Task<OperationResult> AddToken(AddUserTokenCommand command);
   // Task<OperationResult> RemoveToken(RemoveUserTokenCommand command);
   // Task<OperationResult> ChangePassword(ChangeUserPasswordCommand command);

    Task<UserDto?> GetUserByPhoneNumber(string phoneNumber);
    Task<UserDto?> GetUserById(long userId);
  //  Task<UserTokenDto?> GetUserTokenByRefreshToken(string refreshToken);
  //  Task<UserTokenDto?> GetUserTokenByJwtToken(string jwtToken);
    Task<UserFilterResult> GetUserByFilter(UserFilterParams filterParams);
}
