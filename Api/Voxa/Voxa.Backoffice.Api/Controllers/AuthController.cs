using Framework.Application.Contracts.Auth;
using Framework.Application.Models.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Voxa.Application.Model.Users;
using Voxa.Application.Services;

namespace Voxa.Backoffice.Api.Controllers;

[AllowAnonymous]
[ApiController]
[Route("auth")]
public class AuthController : ControllerBase
{
    private readonly UserAppService _userAppService;
    private readonly IAuthJwtService _authJwtService;

    public AuthController(UserAppService userAppService, IAuthJwtService authJwtService)
    {
        _userAppService = userAppService;
        _authJwtService = authJwtService;
    }

    [HttpPost("register")]
    public virtual async Task<IActionResult> Register([FromBody] UserCreateDto dto)
    {
        var result = await _userAppService.CreateAsync(dto);
        return Created(string.Empty, result);
    }

    [HttpPost("login")]
    public virtual async Task<IActionResult> Login([FromBody] AuthLoginRequest request)
    {
        var result = await _authJwtService.AuthenticateAsync(request);
        if (result is null)
            return Unauthorized();
        return Ok(result);
    }
}
