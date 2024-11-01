using MovieApp.DAL.Context;
using MovieApp.DAL.Repositories.Interfaces;

namespace MovieApp.DAL.Repositories.Implementations;

public class UnitOfWork(ApplicationDbContext context) : IUnitOfWork
{
    private RatingRepository? _ratingRepository;

    public IRatingRepository Ratings => _ratingRepository ??= new RatingRepository(context);
    
    private ReviewRepository? _reviewRepository;

    public IReviewRepository Reviews => _reviewRepository ??= new ReviewRepository(context);
    
    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await context.SaveChangesAsync(cancellationToken);
    }

    private bool _disposed = false;

    public virtual void Dispose(bool disposing)
    {
        if (!this._disposed)
        {
            if (disposing)
            {
                context.Dispose();
            }

            this._disposed = true;
        }
    }
    
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}