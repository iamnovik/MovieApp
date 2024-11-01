using Microsoft.Extensions.Configuration;
using MovieApp.DAL.Repositories.Interfaces;

namespace MovieApp.DAL.Repositories.Implementations;

public class ApiUnitOfWork : IApiUnitOfWork
{
    private HttpClient _httpClient;
    private IConfiguration _configuration;
    private string _apiKey;
    public ApiUnitOfWork(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    private ActorRepository? _actorRepository;

    public IActorRepository Actors => _actorRepository ??= new ActorRepository(_httpClient);
    
    private MovieRepository? _movieRepository;

    public IMovieRepository Movies => _movieRepository ??= new MovieRepository(_httpClient);
    
    private ImageRepository? _imageRepository;

    public IImageRepository Images => _imageRepository ??= new ImageRepository(_httpClient);

        
    public void Dispose()
    {
        _httpClient?.Dispose();
    }
}