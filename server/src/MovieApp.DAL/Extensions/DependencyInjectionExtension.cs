

using System.Net.Http.Headers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovieApp.DAL.Context;
using MovieApp.DAL.Context.Models;
using MovieApp.DAL.Repositories.Implementations;
using MovieApp.DAL.Repositories.Interfaces;

namespace MovieApp.DAL.Extensions;

public static class DependencyInjectionExtension
{
    public static IServiceCollection AddDataAccessLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
        
        services.AddHttpClient<IApiUnitOfWork, ApiUnitOfWork>((client) =>
        {
            client.BaseAddress = new Uri("https://api.themoviedb.org/3/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = 
                    new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiI3ZGEzYzA3NjIxYjhhOGM2MGU2MGNmNTkxMjVmNjRiOSIsIm5iZiI6MTcyOTIzNjg5Ny4yMjYwMTUsInN1YiI6IjY3MTIwZDJjMTZjYWE4YjBmMDljMmU1YSIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.BWdSsMZHnzZ3wXkUS1zzT-nxVSt_r5fANMuxiBx7jeY");
        });
        services.AddIdentity<AppUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 6;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        return services;
    }
   
}