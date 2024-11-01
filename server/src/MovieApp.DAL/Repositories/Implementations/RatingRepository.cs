using MovieApp.DAL.Context;
using MovieApp.DAL.Context.Models;
using MovieApp.DAL.Repositories.Interfaces;

namespace MovieApp.DAL.Repositories.Implementations;

public class RatingRepository(ApplicationDbContext context) 
    : BaseRepository<Rating, int>(context), IRatingRepository
{

}