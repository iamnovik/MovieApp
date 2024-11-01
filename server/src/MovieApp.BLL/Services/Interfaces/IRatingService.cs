using MovieApp.BLL.Models.Dto.RatingDto;

namespace MovieApp.BLL.Services.Interfaces;

public interface IRatingService
{
    Task<IEnumerable<RatingReadDto>?> GetRatingsByMovieIdAsync(int movieId,
        CancellationToken cancellationToken = default);
    Task<RatingReadDto> AddRatingAsync(RatingAddDto rating, string userId, CancellationToken cancellationToken = default);
    Task<RatingReadDto> UpdateRatingAsync(RatingUpdateDto rating, CancellationToken cancellationToken = default);
}