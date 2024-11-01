namespace MovieApp.DAL.Repositories.Interfaces;

public interface IMovieRepository
{
    Task<string> GetMovieByIdAsync(int movieId, CancellationToken cancellationToken = default);
    Task<string> GetUpcomingMoviesAsync(int page, CancellationToken cancellationToken = default);

    Task<string> GetSearchMoviesAsync(string query, int page, CancellationToken cancellationToken = default);
}