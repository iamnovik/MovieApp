using MovieApp.BLL.Models.Dto;

namespace MovieApp.BLL.Services.Interfaces;

public interface IImageService
{
    Task<List<PosterDto>?> GetPostersByMovieIdAsync(int movieId, CancellationToken cancellationToken = default);
}