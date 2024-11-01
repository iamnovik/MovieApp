namespace MovieApp.BLL.Models.Dto.WatchList;

public class WatchListReadDto
{
    public int Id { get; set; }
    
    public string UserId { get; set; } = null!;
    
    public int MovieId { get; set; } 
    
    public DateTime AddedAt { get; set; } = DateTime.UtcNow;
    
}