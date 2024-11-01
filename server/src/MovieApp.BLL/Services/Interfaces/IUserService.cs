using Microsoft.AspNetCore.Identity;
using MovieApp.BLL.Models.Dto.UserDto;

namespace MovieApp.BLL.Services.Interfaces;

public interface IUserService
{
    Task<IdentityResult> RegisterUserAsync(UserRegisterDto userDto);

    Task<string> LoginAsync(UserLoginDto userDto);

}