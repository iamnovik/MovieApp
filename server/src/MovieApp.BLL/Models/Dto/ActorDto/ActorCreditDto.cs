namespace MovieApp.BLL.Models.Dto.ActorDto;

public class ActorCreditDto
{
    public int Id { get; set; }             
    public string Character { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string Poster_Path { get; set; } = null!;
}