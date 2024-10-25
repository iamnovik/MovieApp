namespace MovieApp.DAL.Repositories.Interfaces;

public interface IImageRepository
{
    Task<string> GetImagesByMovieIdAsync(int movieId, CancellationToken cancellationToken = default);
}