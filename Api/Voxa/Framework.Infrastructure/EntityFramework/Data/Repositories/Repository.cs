using Framework.Domain.Entities;
using Framework.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Framework.Infrastructure.EntityFramework.Data.Repositories;

public abstract class Repository<TEntity, TId, TGetParams> : IRepository<TEntity, TId, TGetParams>
    where TEntity : class, IEntity<TId>
    where TGetParams : class
{
    protected readonly DbContext Context;
    protected readonly DbSet<TEntity> DbSet;

    protected Repository(DbContext context)
    {
        Context = context;
        DbSet = context.Set<TEntity>();
    }

    public virtual async Task<IList<TEntity>> GetAllAsync(TGetParams? parameters = null)
    {
        return await DbSet.ToListAsync();
    }

    public virtual async Task<TEntity?> GetAsync(TId id)
    {
        return await DbSet.FindAsync(id);
    }

    public virtual async Task<TEntity> CreateAsync(TEntity entity)
    {
        DbSet.Add(entity);
        await Context.SaveChangesAsync();
        return entity;
    }
}