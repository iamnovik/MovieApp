using Microsoft.Extensions.Configuration;
using MovieApp.DAL.Repositories.Interfaces;

namespace MovieApp.DAL.Repositories.Implementations;

public class UnitOfWork : IUnitOfWork
{
    private HttpClient _httpClient;
    private IConfiguration _configuration;
    private string _apiKey;
    public UnitOfWork(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    private ActorRepository? _actorRepository;

    public IActorRepository Actors => _actorRepository ??= new ActorRepository(_httpClient);
    
    private MovieRepository? _movieRepository;

    public IMovieRepository Movies => _movieRepository ??= new MovieRepository(_httpClient);

        
    public void Dispose()
    {
        _httpClient?.Dispose();
    }
}