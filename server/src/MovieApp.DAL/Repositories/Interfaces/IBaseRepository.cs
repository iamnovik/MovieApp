using System.Linq.Expressions;

namespace MovieApp.DAL.Repositories.Interfaces;

public interface IBaseRepository<TEntity, TKey>
{
    Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task<TEntity?> GetByIdAsync(TKey id, CancellationToken cancellationToken = default);
    TEntity Update(TEntity entity);
    Task DeleteAsync(TKey id, CancellationToken cancellationToken = default);
    Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);
    
    Task<IEnumerable<TEntity>> GetAllByFilter(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken = default);
 }