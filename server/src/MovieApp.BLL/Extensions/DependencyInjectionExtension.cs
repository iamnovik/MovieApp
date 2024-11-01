using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovieApp.BLL.Services.Implementations;
using MovieApp.BLL.Services.Interfaces;

namespace MovieApp.BLL.Extensions;

public static class DependencyInjectionExtension
{
    public static IServiceCollection AddBusinessLogicLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IMovieService, MovieService>();
        services.AddScoped<IActorService, ActorService>();
        services.AddScoped<IImageService, ImageService>();
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IRatingService, RatingService>();
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        return services;
    }
}