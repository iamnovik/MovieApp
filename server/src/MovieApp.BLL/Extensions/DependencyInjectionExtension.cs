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

        return services;
    }
}