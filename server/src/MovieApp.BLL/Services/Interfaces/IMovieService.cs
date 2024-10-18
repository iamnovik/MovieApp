using MovieApp.BLL.Models.Dto;

namespace MovieApp.BLL.Services.Interfaces;

public interface IMovieService
{
    Task<List<MovieDto>> GetUpcomingMoviesAsync(int page,CancellationToken cancellationToken = default);
    Task<MovieDto?> GetMovieByIdAsync(int movieId, CancellationToken cancellationToken = default);
    Task<List<MovieDto>?> SearchMoviesAsync(string query, int page, CancellationToken cancellationToken = default);
}