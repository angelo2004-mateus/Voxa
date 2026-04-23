using Framework.Application.Contracts.Auth;
using Microsoft.AspNetCore.Http;

namespace Framework.AspNetCore.Auth;

public class AuthCurrentTenant : ICurrentTenant
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AuthCurrentTenant(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public virtual bool IsAdmin =>
        _httpContextAccessor.HttpContext?.User.IsInRole(AuthRoles.Admin) ?? false;

    public virtual Guid? Id
    {
        get
        {
            var context = _httpContextAccessor.HttpContext;
            if (context is null) return null;

            if (IsAdmin)
            {
                var header = context.Request.Headers["X-Tenant-Id"].FirstOrDefault();
                return Guid.TryParse(header, out var headerId) ? headerId : null;
            }

            var claim = context.User.FindFirst("tenant_id")?.Value;
            return Guid.TryParse(claim, out var claimId) ? claimId : null;
        }
    }
}
