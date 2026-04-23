namespace Framework.Domain.Entities;

public abstract class Entity<TId> : IEntity<TId>
{
    public virtual TId Id { get; set; }
}