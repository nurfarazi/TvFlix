using API.Errors;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("errors/{code}")]
[Route("api/[controller]")]
[ApiExplorerSettings(IgnoreApi = true)]
public class ErrorController : ControllerBase
{
    public IActionResult Error(int code)
    {
        return new ObjectResult(new ApiResponse(code));
    }
}