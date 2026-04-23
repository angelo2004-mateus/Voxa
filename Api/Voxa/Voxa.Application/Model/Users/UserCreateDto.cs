namespace Voxa.Application.Model.Users;

public class UserCreateDto
{
    public virtual string Name { get; set; }
    public virtual string Email { get; set; }
    public virtual string Password { get; set; }
}
