using Framework.Domain.Entities.Interfaces;

namespace Framework.Application.Models.Auth;

public class AuthTenantMembership : IMultiTenant
{
    public virtual Guid? TenantId { get; set; }
    public virtual string TenantRole { get; set; }
}
