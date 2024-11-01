namespace MovieApp.BLL.Models.Dto.RatingDto;

public class RatingAddDto
{
    public int MovieId { get; set; } 
    
    public string UserId { get; set; } = null!;

    public int Score { get; set; } 
}