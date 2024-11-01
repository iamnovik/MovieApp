using MovieApp.BLL.Models.Dto;
using MovieApp.BLL.Models.Dto.MovieDto;

namespace MovieApp.BLL.Models.ApiResponses;

public class MovieCreditsResponse
{
    public int Id { get; set; }              
    public List<CastDto> Cast { get; set; } = null!;
    public List<CrewDto> Crew { get; set; } = null!;
}