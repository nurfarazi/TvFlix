using Core.Entity.Series;
using Core.Interfaces;
using Infrastructure.Services;

namespace API.Controllers;

public class EpisodeController : BaseApiController<Episode>
{
    public EpisodeController(EpisodeService service) : base(service)
    {
    }
}