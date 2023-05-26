using System.Linq.Expressions;

namespace Core.Interfaces;

public interface IGenericRepository<T> where T : class
{
    Task<T> GetByIdAsync(string id);
    Task<IReadOnlyList<T>> ListAllAsync();
    Task<T> SingleOrDefaultAsync(Expression<Func<T,bool>> predict);
        
    Task<T> GetEntityWithSpec(ISpecification<T> spec);
    Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);
    Task<int> CountAsync(ISpecification<T> spec);

    void AddAsync(T entity);
    void AddRangeAsync(List<T> entities);
    void Update(T entity);
        
    void UpdateRangeAsync(List<T> entities);
    void Delete(T entity);
    void DeleteRangeAsync(List<T> entities);
}