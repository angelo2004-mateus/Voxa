namespace Framework.Application.Models.Auth;

public class AuthLoginRequest
{
    public virtual string Email { get; set; }
    public virtual string Password { get; set; }
    public virtual Guid? OrganizationId { get; set; }
}
