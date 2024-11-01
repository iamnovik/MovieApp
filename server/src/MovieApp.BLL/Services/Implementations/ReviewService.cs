using AutoMapper;
using MovieApp.BLL.Models.Dto.ReviewDto;
using MovieApp.BLL.Services.Interfaces;
using MovieApp.DAL.Context.Models;
using MovieApp.DAL.Repositories.Interfaces;

namespace MovieApp.BLL.Services.Implementations;

public class ReviewService(IUnitOfWork unitOfWork, IMapper mapper) : IReviewService
{
    public async Task<IEnumerable<ReviewReadDto>?> GetReviewsByMovieIdAsync(int movieId, CancellationToken cancellationToken = default)
    {
        var reviews = await unitOfWork.Reviews.GetAllByFilter(r => r.MovieId == movieId, cancellationToken);

        return mapper.Map<IEnumerable<ReviewReadDto>>(reviews);
    }

    public async Task<ReviewReadDto> AddReviewAsync(ReviewAddDto reviewDto, string userId, CancellationToken cancellationToken = default)
    {
        if (reviewDto == null) throw new ArgumentNullException(nameof(reviewDto));
        var review = mapper.Map<Review>(reviewDto);
        review.UserId = userId;
        var createdReview = await unitOfWork.Reviews.AddAsync(review, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        
        return mapper.Map<ReviewReadDto>(createdReview);
    }

    public async Task<ReviewReadDto> UpdateReviewAsync(ReviewUpdateDto reviewDto, CancellationToken cancellationToken = default)
    {
        if (reviewDto == null) throw new ArgumentNullException(nameof(reviewDto));
          
        var review = mapper.Map<Review>(reviewDto);

        var reviewToUpdate = await unitOfWork.Reviews.GetByIdAsync(review.Id);

        if (reviewToUpdate == null) throw new ArgumentException();

        reviewToUpdate.Content = review.Content;
        
        var updatedReview = unitOfWork.Reviews.Update(reviewToUpdate);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        
        return mapper.Map<ReviewReadDto>(updatedReview);
    }
}