namespace MovieApp.DAL.Context.Models;

public class Review
{
    public int Id { get; set; }
    public string Content { get; set; } = null!;
    public int MovieId { get; set; }
    public string UserId { get; set; } = null!;
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    public AppUser AppUser;
}