using Core.Entity.Series;
using Core.Interfaces;

namespace Infrastructure.Services;

public class SeasonService : Service<Season>
{
    public SeasonService(IGenericRepository<Season> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
    {
    }
}