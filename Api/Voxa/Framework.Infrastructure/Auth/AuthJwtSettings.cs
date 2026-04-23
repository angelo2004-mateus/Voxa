namespace Framework.Infrastructure.Auth;

public class AuthJwtSettings
{
    public const string SectionName = "Jwt";
    public virtual string SecretKey { get; set; }
    public virtual string Issuer { get; set; }
    public virtual string Audience { get; set; }
    public virtual int ExpirationMinutes { get; set; }

    public AuthJwtSettings()
    {
        ExpirationMinutes = 60;
    }
}
