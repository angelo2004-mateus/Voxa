namespace Framework.Application.Models.Auth;

public class AuthUser
{
    public virtual Guid Id { get; set; }
    public virtual string Email { get; set; }
    public virtual string PasswordHash { get; set; }
    public virtual string Role { get; set; }
    public virtual IList<AuthTenantMembership> Memberships { get; set; }
}
