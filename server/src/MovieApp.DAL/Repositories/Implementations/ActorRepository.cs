using Microsoft.Extensions.Configuration;
using MovieApp.DAL.ApiQueryParameters;
using MovieApp.DAL.Repositories.Interfaces;

namespace MovieApp.DAL.Repositories.Implementations;

public class ActorRepository : 
    BaseRepository,IActorRepository
{
    public ActorRepository(HttpClient httpClient) : base(httpClient)
    {
        
    }
    public async Task<string> GetActorsByMovieIdAsync(int movieId, CancellationToken cancellationToken = default)
    {
        var requestUri = $"movie/{movieId}/credits";
        return await ApiGetQuery(requestUri);
    }

    public async Task<string> GetActorByIdAsync(int actorId, CancellationToken cancellationToken = default)
    {
        var requestUri = $"person/{actorId}";
        return await ApiGetQuery(requestUri);
    }

    public async Task<string> GetActorCreditsByIdAsync(int actorId, CancellationToken cancellationToken = default)
    {
        var requestUri = $"person/{actorId}/combined_credits";
        return await ApiGetQuery(requestUri);
    }

    public async Task<string> GetSearchActorAsync(string query, int page, CancellationToken cancellationToken = default)
    {
        var requestUri = $"search/person?query={query}&include_adult={ApiRequestParameters.MovieApi.IncludeAdult}&page={page}";
        return await ApiGetQuery(requestUri);
    }

}