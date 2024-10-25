using MovieApp.BLL.Models.ApiResponses;
using MovieApp.BLL.Models.Dto;

namespace MovieApp.BLL.Services.Interfaces;

public interface IMovieService
{
    Task<MovieSearchResponse?> GetUpcomingMoviesAsync(int page,CancellationToken cancellationToken = default);
    Task<MovieDto?> GetMovieByIdAsync(int movieId, CancellationToken cancellationToken = default);
    Task<MovieSearchResponse?> SearchMoviesAsync(string query, int page, CancellationToken cancellationToken = default);
}