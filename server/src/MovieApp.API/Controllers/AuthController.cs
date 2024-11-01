using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Mvc;
using MovieApp.BLL.Models.Dto.UserDto;
using MovieApp.BLL.Services.Interfaces;

namespace MovieApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController(IUserService userService ) : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] UserRegisterDto userDto)
    {
        var result = await userService.RegisterUserAsync(userDto);

        if (result.Succeeded)
            return Ok(new { message = "User registered successfully!" });

        return BadRequest(result.Errors);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UserLoginDto userDto)
    {
        var token = await userService.LoginAsync(userDto);
        
        return Ok(new { Token = token });
    }
}