using MovieApp.BLL.Models.Dto.WatchList;

namespace MovieApp.BLL.Services.Interfaces;

public interface IWatchListService
{
    Task<IEnumerable<WatchListReadDto>?> GetWatchListsByUserIdAsync(string userId,
        CancellationToken cancellationToken = default);
    
    Task<IEnumerable<WatchListReadDto>?> GetWatchListsByMovieIdAsync(int movie,
        CancellationToken cancellationToken = default);
    Task<WatchListReadDto> AddWatchListAsync(WatchListAddDto watchList, string userId, CancellationToken cancellationToken = default);
    Task<bool> DeleteWatchListAsync(int id, CancellationToken cancellationToken = default);

}