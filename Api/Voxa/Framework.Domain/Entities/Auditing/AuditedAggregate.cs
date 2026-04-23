namespace Framework.Domain.Entities.Auditing;

public abstract class AuditedAggregate<TId> : Entity<TId>, IAudited
{
    public virtual DateTime CreationTime { get; set; }
    public virtual DateTime? UpdatedTime { get; set; }
}