using Framework.Application.Contracts.Auth;
using Framework.AspNetCore.Auth;
using Framework.AspNetCore.Controllers;
using Microsoft.AspNetCore.Mvc;
using Voxa.Application.Model.Users;
using Voxa.Application.Services;
using Voxa.Domain.Users;

namespace Voxa.Backoffice.Api.Controllers;

[AuthProtected(AuthRoles.Admin)]
[Route("users")]
public class UsersController : CrudController<User, Guid, UserDto>
{
    public UsersController(UserAppService appService) : base(appService)
    {
    }
}
