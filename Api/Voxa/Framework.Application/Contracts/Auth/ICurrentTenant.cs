namespace Framework.Application.Contracts.Auth;

public interface ICurrentTenant
{
    Guid? Id { get; }
    bool IsAdmin { get; }
}
