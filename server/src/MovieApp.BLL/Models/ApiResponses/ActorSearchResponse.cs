using MovieApp.BLL.Models.Dto;
using MovieApp.BLL.Models.Dto.ActorDto;

namespace MovieApp.BLL.Models.ApiResponses;

public class ActorSearchResponse
{
    public List<ActorSearchDto> Results { get; set; }
    public int Page { get; set; }
    public int Total_Pages { get; set; }
}