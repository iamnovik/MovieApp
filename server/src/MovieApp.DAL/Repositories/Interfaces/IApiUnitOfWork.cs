namespace MovieApp.DAL.Repositories.Interfaces;

public interface IApiUnitOfWork : IDisposable
{
    IActorRepository Actors { get; }
    
    IMovieRepository Movies { get; }
    
    IImageRepository Images { get; }

}