using MovieApp.BLL.Models.ApiResponses;
using MovieApp.BLL.Models.Dto;
using MovieApp.BLL.Services.Interfaces;
using MovieApp.DAL.Repositories.Interfaces;
using Newtonsoft.Json;

namespace MovieApp.BLL.Services.Implementations;

public class ActorService(IUnitOfWork unitOfWork) : IActorService
{
    public async Task<List<CastDto>?> GetActorsByMovieIdAsync(int actorId, CancellationToken cancellationToken = default)
    {
        var creditsJson = await unitOfWork.Actors.GetActorsByMovieIdAsync(actorId);
        var actorApiResponse = JsonConvert.DeserializeObject<MovieCreditsResponse>(creditsJson);

        return actorApiResponse?.Cast;
    }

    public async Task<ActorDto?> GetActorByIdAsync(int actorId, CancellationToken cancellationToken = default)
    {
        var actorJson = await unitOfWork.Actors.GetActorByIdAsync(actorId);

        var actorApiResponse = JsonConvert.DeserializeObject<ActorDto>(actorJson);

        return actorApiResponse;
    }

    public async Task<List<ActorCreditDto>?> GetActorCreditsByIdAsync(int actorId, CancellationToken cancellationToken = default)
    {
        var actorCreditsJson = await unitOfWork.Actors.GetActorCreditsByIdAsync(actorId);

        var actorApiResponse = JsonConvert.DeserializeObject<ActorCreditResponse>(actorCreditsJson);

        return actorApiResponse?.Cast;
    }

    public async Task<List<ActorSearchDto>?> SearchActorsAsync(string query, int page, CancellationToken cancellationToken = default)
    {
        var actorsJson = await unitOfWork.Actors.GetSearchActorAsync(query,page);
        var actorApiResponse = JsonConvert.DeserializeObject<ActorSearchResponse>(actorsJson);
        return actorApiResponse?.Results;
    }
}