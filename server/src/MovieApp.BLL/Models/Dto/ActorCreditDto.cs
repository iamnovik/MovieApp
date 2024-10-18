namespace MovieApp.BLL.Models.Dto;

public class ActorCreditDto
{
    public int Id { get; set; }             
    public string Character { get; set; } = null!;
    public string Title { get; set; } = null!;
}