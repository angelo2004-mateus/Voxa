using Framework.Application.Contracts;
using Framework.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Framework.AspNetCore.Controllers;

[ApiController]
public abstract class CrudController<TEntity, TId, TDto> : ControllerBase
    where TEntity : IEntity<TId>
{
    protected readonly IApplicationService<TEntity, TId, TDto> AppService;

    protected CrudController(IApplicationService<TEntity, TId, TDto> appService)
    {
        AppService = appService;
    }

    [HttpGet]
    public virtual async Task<IActionResult> GetAll()
    {
        var result = await AppService.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public virtual async Task<IActionResult> Get(TId id)
    {
        var result = await AppService.GetAsync(id);
        return Ok(result);
    }

    [HttpPost]
    public virtual async Task<IActionResult> Post([FromBody] TDto dto)
    {
        var result = await AppService.PostAsync(dto);
        return Created(string.Empty, result);
    }
}
