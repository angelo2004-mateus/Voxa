using Framework.Domain.Entities;

namespace Framework.Domain.Repositories;

public interface IRepository<TEntity, TId, TGetParams>
    where TEntity : IEntity<TId>
    where TGetParams : class
{
    Task<IList<TEntity>> GetAllAsync(TGetParams? parameters = null);
    Task<TEntity?> GetAsync(TId id);
    Task<TEntity> CreateAsync(TEntity entity);
}