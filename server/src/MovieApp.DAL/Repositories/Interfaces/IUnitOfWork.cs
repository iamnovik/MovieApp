namespace MovieApp.DAL.Repositories.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IActorRepository Actors { get; }
    
    IMovieRepository Movies { get; }

}