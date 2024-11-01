using MovieApp.BLL.Models.Dto.ReviewDto;

namespace MovieApp.BLL.Services.Interfaces;

public interface IReviewService
{
    Task<IEnumerable<ReviewReadDto>?> GetReviewsByMovieIdAsync(int movieId,
        CancellationToken cancellationToken = default);
    Task<ReviewReadDto> AddReviewAsync(ReviewAddDto review, string userId, CancellationToken cancellationToken = default);
    Task<ReviewReadDto> UpdateReviewAsync(ReviewUpdateDto review, CancellationToken cancellationToken = default);

    Task<bool> DeleteReviewAsync(int id, CancellationToken cancellationToken = default);
}