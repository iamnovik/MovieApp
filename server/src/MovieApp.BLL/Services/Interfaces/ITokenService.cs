using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace MovieApp.BLL.Services.Interfaces;

public interface ITokenService
{
    string GenerateToken(IdentityUser user);
}