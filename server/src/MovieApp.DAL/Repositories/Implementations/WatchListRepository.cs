using MovieApp.DAL.Context;
using MovieApp.DAL.Context.Models;
using MovieApp.DAL.Repositories.Interfaces;

namespace MovieApp.DAL.Repositories.Implementations;

public class WatchListRepository(ApplicationDbContext context)
    : BaseRepository<WatchList, int>(context), IWatchListRepository;