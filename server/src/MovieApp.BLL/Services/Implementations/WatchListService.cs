using AutoMapper;
using MovieApp.BLL.Models.Dto.WatchList;
using MovieApp.BLL.Services.Interfaces;
using MovieApp.DAL.Context.Models;
using MovieApp.DAL.Repositories.Interfaces;

namespace MovieApp.BLL.Services.Implementations;

public class WatchListService(IUnitOfWork unitOfWork, IMapper mapper) : IWatchListService
{
    public async Task<IEnumerable<WatchListReadDto>?> GetWatchListsByUserIdAsync(string userId, CancellationToken cancellationToken = default)
    {
        var watchLists = await unitOfWork.WatchLists.GetAllByFilter(r => r.UserId == userId, cancellationToken);

        return mapper.Map<IEnumerable<WatchListReadDto>>(watchLists);
    }

    public async Task<IEnumerable<WatchListReadDto>?> GetWatchListsByMovieIdAsync(int movieId, CancellationToken cancellationToken = default)
    {
        var watchLists = await unitOfWork.WatchLists.GetAllByFilter(r => r.MovieId == movieId, cancellationToken);

        return mapper.Map<IEnumerable<WatchListReadDto>>(watchLists);
    }

    public async Task<WatchListReadDto> AddWatchListAsync(WatchListAddDto watchListDto, string userId, CancellationToken cancellationToken = default)
    {
        if (watchListDto == null) throw new ArgumentNullException(nameof(watchListDto));
        var watchList = mapper.Map<WatchList>(watchListDto);
        watchList.UserId = userId;
        var createdWatchList = await unitOfWork.WatchLists.AddAsync(watchList, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        
        return mapper.Map<WatchListReadDto>(createdWatchList);
    }

    public async Task<bool> DeleteWatchListAsync(int id, CancellationToken cancellationToken = default)
    {
        var watchList = await unitOfWork.WatchLists.GetByIdAsync(id, cancellationToken);

        if (watchList != null)
        {
            await unitOfWork.WatchLists.DeleteAsync(watchList, cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return true;
        }

        return false;
    }
}