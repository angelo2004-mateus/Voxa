using Microsoft.AspNetCore.Authorization;

namespace Framework.AspNetCore.Auth;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
public class AuthProtectedAttribute : AuthorizeAttribute
{
    public virtual string[] Permissions { get; set; }
    public virtual bool RequireAll { get; set; }
    public virtual string Area { get; set; }

    public AuthProtectedAttribute(params string[] roles)
    {
        Roles = string.Join(",", roles);
        Permissions = roles;
    }
}
