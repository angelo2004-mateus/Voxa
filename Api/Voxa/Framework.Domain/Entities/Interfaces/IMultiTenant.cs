namespace Framework.Domain.Entities.Interfaces;

public interface IMultiTenant
{
    Guid? TenantId { get; set; }
}
