namespace MovieApp.BLL.Models.Dto.RatingDto;

public class RatingReadDto
{
    public int Id { get; set; }
    
    public int MovieId { get; set; } 
    
    public string UserId { get; set; } = null!;

    public int Score { get; set; } 
    
    public DateTime CreatedAt { get; set; } 
}