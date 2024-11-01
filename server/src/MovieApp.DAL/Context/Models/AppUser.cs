using Microsoft.AspNetCore.Identity;

namespace MovieApp.DAL.Context.Models;

public sealed class AppUser : IdentityUser
{
    public ICollection<Review> Reviews { get; set; } = new List<Review>();
    public ICollection<Rating> Ratings { get; set; } = new List<Rating>();
}