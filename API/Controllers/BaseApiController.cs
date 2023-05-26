using API.Errors;
using Core.Const;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class BaseApiController<TEntity> : ControllerBase where TEntity : class
{
    private readonly Service<TEntity> service;

    public BaseApiController(Service<TEntity> service)
    {
        this.service = service;
    }

    [HttpGet]
    public virtual async Task<ActionResult<IReadOnlyList<TEntity>>> GetAllAsync()
    {
        return Ok(await this.service.ListAllAsync());
    }

    [HttpPost]
    public virtual async Task<IActionResult> CreateAsync(TEntity entity)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(new ApiResponse(400));
        }

        await this.service.AddAsync(entity);

        return Ok();
    }

    [HttpGet("{id}")]
    public virtual async Task<ActionResult<TEntity>> GetByIdAsync(string id)
    {
        return await this.service.GetByIdAsync(id);
    }

    [HttpPut("{id}")]
    [Authorize]
    public virtual async Task<IActionResult> EditAsync(string id, TEntity entity)
    {
        if (!ModelState.IsValid) return BadRequest(new ApiResponse(400));

        try
        {
            await this.service.UpdateAsync(entity);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(new ApiResponse(400, e.Message));
        }
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = SystemRoles.Admin)]
    public virtual async Task<int> DeleteAsync(string id)
    {
        return await this.service.DeleteAsync(id);
    }
}