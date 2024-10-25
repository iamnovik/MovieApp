using MovieApp.BLL.Models.ApiResponses;
using MovieApp.BLL.Models.Dto;
using MovieApp.BLL.Services.Interfaces;
using MovieApp.DAL.Repositories.Interfaces;
using Newtonsoft.Json;

namespace MovieApp.BLL.Services.Implementations;

public class ImageService(IUnitOfWork unitOfWork) : IImageService
{
    public async Task<List<PosterDto>?> GetPostersByMovieIdAsync(int movieId, CancellationToken cancellationToken = default)
    {
        var imagesJson = await unitOfWork.Images.GetImagesByMovieIdAsync(movieId);
        var actorApiResponse = JsonConvert.DeserializeObject<ImageGetResponse>(imagesJson);

        return actorApiResponse?.Posters;
    }
}