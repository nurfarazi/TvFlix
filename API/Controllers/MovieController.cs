using Core.Entity.Movies;
using Infrastructure.Services;

namespace API.Controllers;

public class MovieController : BaseApiController<Movie>
{
    public MovieController(MovieService service) : base(service)
    {
    }
}