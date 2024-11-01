using MovieApp.BLL.Models.ApiResponses;
using MovieApp.BLL.Models.Dto;
using MovieApp.BLL.Services.Interfaces;
using MovieApp.DAL.Repositories.Interfaces;
using Newtonsoft.Json;

namespace MovieApp.BLL.Services.Implementations;

public class MovieService(IUnitOfWork unitOfWork) : IMovieService
{
    public async Task<MovieSearchResponse?> GetUpcomingMoviesAsync(int page, CancellationToken cancellationToken = default)
    {
        var moviesJson = await unitOfWork.Movies.GetUpcomingMoviesAsync(page);
        var movieApiResponse = JsonConvert.DeserializeObject<MovieSearchResponse>(moviesJson);

        return movieApiResponse;
    }

    public async Task<MovieDto?> GetMovieByIdAsync(int movieId, CancellationToken cancellationToken = default)
    {
        var movieJson = await unitOfWork.Movies.GetMovieByIdAsync(movieId,cancellationToken);
        var movieDto = JsonConvert.DeserializeObject<MovieDto>(movieJson);

        return movieDto;
    }

    public async Task<MovieSearchResponse?> SearchMoviesAsync(string query, int page, CancellationToken cancellationToken = default)
    {
        var moviesJson = await unitOfWork.Movies.GetSearchMoviesAsync(query,page);
        var movieApiResponse = JsonConvert.DeserializeObject<MovieSearchResponse>(moviesJson);
        return movieApiResponse;
    }
}