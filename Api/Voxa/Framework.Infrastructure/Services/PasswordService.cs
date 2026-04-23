using DevOne.Security.Cryptography.BCrypt;
using Framework.Domain.Services;


namespace Framework.Infrastructure.Services;

public class PasswordService : IPasswordService
{
    public string Hash(string password)
    {
        var salt = BCryptHelper.GenerateSalt();
        return BCryptHelper.HashPassword(password, salt);
    }

    public bool Verify(string password, string hashed)
    {
        return BCryptHelper.CheckPassword(password, hashed);
    }
}