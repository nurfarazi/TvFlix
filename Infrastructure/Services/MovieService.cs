using Core.Entity;
using Core.Entity.Movies;
using Core.Interfaces;

namespace Infrastructure.Services;

public class MovieService : Service<Movie>
{
    public MovieService(IGenericRepository<Movie> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
    {
    }
}