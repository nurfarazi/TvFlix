using Core.Entity.Series;
using Core.Interfaces;

namespace Infrastructure.Services;

public class EpisodeService : Service<Episode>
{
    public EpisodeService(IGenericRepository<Episode> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
    {
    }
}