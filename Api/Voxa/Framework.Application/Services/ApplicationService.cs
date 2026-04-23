using Framework.Application.Contracts;
using Framework.Domain.Entities;
using Framework.Domain.Repositories;

namespace Framework.Application.Services;

public abstract class ApplicationService<TEntity, TId, TDto, TGetParams> : IApplicationService<TEntity, TId, TDto>
    where TEntity : class, IEntity<TId>
    where TGetParams : class
{
    protected readonly IRepository<TEntity, TId, TGetParams> Repository;

    protected ApplicationService(IRepository<TEntity, TId, TGetParams> repository)
    {
        Repository = repository;
    }

    public abstract Task<IList<TDto>> GetAllAsync();
    public abstract Task<TDto> GetAsync(TId id);
    public abstract Task<TDto> PostAsync(TDto dto);
}