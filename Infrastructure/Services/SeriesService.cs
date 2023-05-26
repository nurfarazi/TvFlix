using Core.Entity.Series;
using Core.Interfaces;

namespace Infrastructure.Services;

public class SeriesService : Service<Series>
{
    public SeriesService(IGenericRepository<Series> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
    {
    }
}