namespace Framework.Application.Contracts.Auth;

public interface IAuthJwtGenerator
{
    string Generate(Dictionary<string, string> claims);
}
