namespace MovieApp.DAL.Repositories.Interfaces;

public interface IUnitOfWork
{
    IReviewRepository Reviews { get; }
    
    IRatingRepository Ratings { get; }
    
    IWatchListRepository WatchLists { get; }

    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}