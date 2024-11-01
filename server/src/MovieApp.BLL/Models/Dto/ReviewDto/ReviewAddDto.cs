namespace MovieApp.BLL.Models.Dto.ReviewDto;

public class ReviewAddDto
{
    public string Content { get; set; } = null!;
    
    public int MovieId { get; set; }
    
    public string UserId { get; set; } = null!;
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}