using MovieApp.BLL.Models.ApiResponses;
using MovieApp.BLL.Models.Dto;

namespace MovieApp.BLL.Services.Interfaces;

public interface IActorService
{
    Task<List<CastDto>?> GetActorsByMovieIdAsync(int movieId, CancellationToken cancellationToken = default);
    Task<ActorDto?> GetActorByIdAsync(int actorId, CancellationToken cancellationToken = default);

    Task<List<ActorCreditDto>?> GetActorCreditsByIdAsync(int actorId, CancellationToken cancellationToken = default);
    Task<List<ActorSearchDto>?> SearchActorsAsync(string query, int page, CancellationToken cancellationToken = default);
}