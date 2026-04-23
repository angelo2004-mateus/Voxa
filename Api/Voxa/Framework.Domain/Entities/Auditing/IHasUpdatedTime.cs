namespace Framework.Domain.Entities.Auditing;

public interface IHasUpdatedTime
{
    DateTime? UpdatedTime { get; set; }
}