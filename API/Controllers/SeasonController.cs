using Core.Entity.Series;
using Infrastructure.Services;

namespace API.Controllers;

public class SeasonController : BaseApiController<Season>
{
    public SeasonController(SeasonService service) : base(service)
    {
    }
}