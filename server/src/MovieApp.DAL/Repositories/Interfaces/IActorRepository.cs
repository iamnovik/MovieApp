namespace MovieApp.DAL.Repositories.Interfaces;

public interface IActorRepository
{
    Task<string> GetActorsByMovieIdAsync(int movieId, CancellationToken cancellationToken = default);
    Task<string> GetActorByIdAsync(int actorId, CancellationToken cancellationToken = default);

    Task<string> GetActorCreditsByIdAsync(int actorId, CancellationToken cancellationToken = default);
    
    Task<string> GetSearchActorAsync(string query, int page, CancellationToken cancellationToken = default);
}