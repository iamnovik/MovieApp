using MovieApp.DAL.Repositories.Interfaces;

namespace MovieApp.DAL.Repositories.Implementations;

public class ImageRepository(HttpClient httpClient) :
    BaseApiRepository(httpClient), IImageRepository
{

    public async Task<string> GetImagesByMovieIdAsync(int movieId, CancellationToken cancellationToken = default)
    {
        var requestUri = $"movie/{movieId}/images";
        return await ApiGetQuery(requestUri);
    }
}