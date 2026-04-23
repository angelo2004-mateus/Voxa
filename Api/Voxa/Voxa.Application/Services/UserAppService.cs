using Framework.Application.Services;
using Framework.Domain.Repositories;
using Framework.Domain.Services;
using Voxa.Application.Model.Users;
using Voxa.Domain.Users;

namespace Voxa.Application.Services;

public class UserAppService : ApplicationService<User, Guid, UserDto, UserGetParams>
{
    private readonly IPasswordService _passwordService;

    public UserAppService(
        IRepository<User, Guid, UserGetParams> repository,
        IPasswordService passwordService) : base(repository)
    {
        _passwordService = passwordService;
    }

    public override async Task<IList<UserDto>> GetAllAsync()
    {
        var users = await Repository.GetAllAsync();
        return users.Select(MapToDto).ToList();
    }

    public override async Task<UserDto> GetAsync(Guid id)
    {
        var user = await Repository.GetAsync(id)
            ?? throw new KeyNotFoundException($"User {id} not found.");
        return MapToDto(user);
    }

    public override async Task<UserDto> PostAsync(UserDto dto)
    {
        var user = new User { Name = dto.Name, Email = dto.Email };
        var created = await Repository.CreateAsync(user);
        return MapToDto(created);
    }

    public virtual async Task<UserDto> CreateAsync(UserCreateDto dto)
    {
        var user = new User
        {
            Name = dto.Name,
            Email = dto.Email,
            Password = _passwordService.Hash(dto.Password)
        };
        var created = await Repository.CreateAsync(user);
        return MapToDto(created);
    }

    private static UserDto MapToDto(User user) => new()
    {
        Id = user.Id,
        Name = user.Name,
        Email = user.Email
    };
}
