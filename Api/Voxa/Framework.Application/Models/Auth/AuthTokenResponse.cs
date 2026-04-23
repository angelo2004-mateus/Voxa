namespace Framework.Application.Models.Auth;

public class AuthTokenResponse
{
    public virtual string Token { get; set; }
    public virtual DateTime Expiration { get; set; }
}
