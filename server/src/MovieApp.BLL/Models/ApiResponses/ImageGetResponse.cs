using MovieApp.BLL.Models.Dto;
using MovieApp.BLL.Models.Dto.MovieDto;

namespace MovieApp.BLL.Models.ApiResponses;

public class ImageGetResponse
{
    public List<PosterDto> Posters = null!;
}