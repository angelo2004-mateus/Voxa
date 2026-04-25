namespace Voxa.Domain.Users;

public class UserEmailAlreadyInUseException : Exception
{
    public UserEmailAlreadyInUseException(string email)
        : base($"Email '{email}' já está em uso.")
    {
    }
}
