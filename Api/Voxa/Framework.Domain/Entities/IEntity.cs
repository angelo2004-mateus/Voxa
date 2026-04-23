namespace Framework.Domain.Entities;

public interface IEntity<TId> : IEntity
{
    TId Id { get; set; }
}

public interface IEntity
{
    
}