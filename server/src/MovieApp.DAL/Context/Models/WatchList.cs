namespace MovieApp.DAL.Context.Models;

public class WatchList
{
    public int Id { get; set; }
    public string UserId { get; set; } = null!;
    public int MovieId { get; set; } 
    public DateTime AddedAt { get; set; } = DateTime.UtcNow;
    
    public AppUser User { get; set; } = null!;
}