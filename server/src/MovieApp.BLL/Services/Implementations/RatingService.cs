using System.Security.Claims;
using AutoMapper;
using MovieApp.BLL.Models.Dto.RatingDto;
using MovieApp.BLL.Services.Interfaces;
using MovieApp.DAL.Context.Models;
using MovieApp.DAL.Repositories.Interfaces;

namespace MovieApp.BLL.Services.Implementations;

public class RatingService(IUnitOfWork unitOfWork, IMapper mapper) : IRatingService
{
    public async Task<IEnumerable<RatingReadDto>?> GetRatingsByMovieIdAsync(int movieId, CancellationToken cancellationToken = default)
    {
        var ratings = await unitOfWork.Ratings.GetAllByFilter(r => r.MovieId == movieId, cancellationToken);

        return mapper.Map<IEnumerable<RatingReadDto>>(ratings);
    }

    public async Task<RatingReadDto> AddRatingAsync(RatingAddDto ratingDto, CancellationToken cancellationToken = default)
    {
        if (ratingDto == null) throw new ArgumentNullException(nameof(ratingDto));
          
        var rating = mapper.Map<Rating>(ratingDto);
        var createdRating = await unitOfWork.Ratings.AddAsync(rating, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        
        return mapper.Map<RatingReadDto>(createdRating);
    }

    public async Task<RatingReadDto> UpdateRatingAsync(RatingUpdateDto ratingDto, CancellationToken cancellationToken = default)
    {
        if (ratingDto == null) throw new ArgumentNullException(nameof(ratingDto));
          
        var rating = mapper.Map<Rating>(ratingDto);

        var ratingToUpdate = await unitOfWork.Ratings.GetByIdAsync(rating.Id);

        if (ratingToUpdate == null) throw new ArgumentException();

        ratingToUpdate.Score = rating.Score;
        
        var updatedRating = unitOfWork.Ratings.Update(ratingToUpdate);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        
        return mapper.Map<RatingReadDto>(updatedRating);
    }
}