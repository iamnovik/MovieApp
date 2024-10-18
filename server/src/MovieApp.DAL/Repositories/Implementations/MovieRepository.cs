using Microsoft.Extensions.Configuration;
using MovieApp.DAL.Repositories.Interfaces;
using MovieApp.DAL.ApiQueryParameters;
namespace MovieApp.DAL.Repositories.Implementations;

public class MovieRepository : 
    BaseRepository,IMovieRepository
{
    public MovieRepository(HttpClient httpClient ) : base(httpClient)
    {
        
    }
    public async Task<string> GetMovieByIdAsync(int movieId, CancellationToken cancellationToken = default)
    {
        var requestUri = $"movie/{movieId}";
        return await ApiGetQuery(requestUri);
    }

    public async Task<string> GetUpcomingMoviesAsync(int page, CancellationToken cancellationToken = default)
    {
        
        var requestUri = $"discover/movie?include_adult={ApiRequestParameters.MovieApi.IncludeAdult}&include_video={ApiRequestParameters.MovieApi.IncludeVideo}&language={ApiRequestParameters.MovieApi.Language}" +
                         $"&page={page}&sort_by={ApiRequestParameters.SortOptions.SortByPopularityDesc}" +
                         $"&with_release_type=2|3" +
                         $"&release_date.gte={ApiRequestParameters.DateFilters.GetMinDate()}&release_date.lte={ApiRequestParameters.DateFilters.GetMaxDate()}";
        
        return await ApiGetQuery(requestUri);
    }

    public async Task<string> GetSearchMoviesAsync(string query, int page, CancellationToken cancellationToken = default)
    {
        var requestUri = $"search/movie?query={query}&include_adult={ApiRequestParameters.MovieApi.IncludeAdult}&page={page}";

        return await ApiGetQuery(requestUri);
    }
}