namespace MovieApp.BLL.Models.Dto.ReviewDto;

public class ReviewAddDto
{
    public string Content { get; set; } = null!;
    
    public int MovieId { get; set; }
    
}