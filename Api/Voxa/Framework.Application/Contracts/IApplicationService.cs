using Framework.Domain.Entities;

namespace Framework.Application.Contracts;

public interface IApplicationService<TEntity, TId, TDto>
    where TEntity : IEntity<TId>
{
    Task<IList<TDto>> GetAllAsync();
    Task<TDto> GetAsync(TId id);
    Task<TDto> PostAsync(TDto dto);
}

public interface IApplicationService
{
}