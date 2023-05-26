using Core.Entity.Series;
using Infrastructure.Services;

namespace API.Controllers;

public class SeriesController : BaseApiController<Series>
{
    public SeriesController(SeriesService service) : base(service)
    {
    }
}