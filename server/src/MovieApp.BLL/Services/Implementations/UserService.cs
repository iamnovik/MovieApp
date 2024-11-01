using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using MovieApp.BLL.Models.Dto.UserDto;
using MovieApp.BLL.Services.Interfaces;
using MovieApp.DAL.Context.Models;

namespace MovieApp.BLL.Services.Implementations;

public class UserService(UserManager<AppUser> _userManager, IMapper _mapper, ITokenService tokenService) : IUserService
{
    
    public async Task<IdentityResult> RegisterUserAsync(UserRegisterDto userDto)
    {
        var user = _mapper.Map<AppUser>(userDto);
        return await _userManager.CreateAsync(user, userDto.Password);
    }

    public async Task<string> LoginAsync(UserLoginDto userDto)
    {
        var user = await _userManager.FindByEmailAsync(userDto.Email);

        if (user == null || !await _userManager.CheckPasswordAsync(user, userDto.Password))
        {
            throw new UnauthorizedAccessException("Invalid username or password");
        }
        
        var token = tokenService.GenerateToken(user);
        return token;
    }
    
}