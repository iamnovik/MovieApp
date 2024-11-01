using MovieApp.BLL.Models.Dto;
using MovieApp.BLL.Models.Dto.MovieDto;

namespace MovieApp.BLL.Models.ApiResponses;

public class MovieSearchResponse
{
    public List<MovieDto> Results { get; set; }
    public int Page { get; set; }
    public int Total_Pages { get; set; }
}