using MovieApp.BLL.Models.Dto;

namespace MovieApp.BLL.Models.ApiResponses;

public class ActorCreditResponse
{
    public List<ActorCreditDto> Cast { get; set; } = null!;
}
