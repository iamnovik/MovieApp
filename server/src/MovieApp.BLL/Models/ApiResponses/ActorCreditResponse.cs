using MovieApp.BLL.Models.Dto.ActorDto;

namespace MovieApp.BLL.Models.ApiResponses;

public class ActorCreditResponse
{
    public List<ActorCreditDto> Cast { get; set; } = null!;
}
