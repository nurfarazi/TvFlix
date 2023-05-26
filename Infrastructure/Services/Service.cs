using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Interfaces;

namespace Infrastructure.Services;

public class Service<TEntity> : IService<TEntity> where TEntity : class
{
    public Service(IGenericRepository<TEntity> repository, IUnitOfWork unitOfWork)
    {
        Repository = repository;
        UnitOfWork = unitOfWork;
    }

    protected IUnitOfWork UnitOfWork { get; private set; }

    protected IGenericRepository<TEntity> Repository { get; private set; }


    public virtual Task<TEntity> GetByIdAsync(string id)
    {
        return Repository.GetByIdAsync(id);
    }
    public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predict)
    {
        return await Repository.SingleOrDefaultAsync(predict);
    }

    public virtual Task<IReadOnlyList<TEntity>> ListAllAsync()
    {
        return Repository.ListAllAsync();
    }

    public virtual Task<TEntity> GetEntityWithSpec(ISpecification<TEntity> specification)
    {
        return Repository.GetEntityWithSpec(specification);
    }

    public virtual Task<IReadOnlyList<TEntity>> ListAsync(ISpecification<TEntity> specification)
    {
        return Repository.ListAsync(specification);
    }

    public virtual Task<int> CountAsync(ISpecification<TEntity> specification)
    {
        return Repository.CountAsync(specification);
    }

    public virtual Task AddAsync(TEntity entity)
    {
        Repository.AddAsync(entity);
        var task = UnitOfWork.Complete();
        return task;
    }

    public virtual Task AddRangeAsync(List<TEntity> entities)
    {
        Repository.AddRangeAsync(entities);
        var task = UnitOfWork.Complete();
        return task;
    }

    public virtual Task UpdateAsync(TEntity entity)
    {
        Repository.Update(entity);
        var task = UnitOfWork.Complete();
        return task;
    }

    public virtual Task UpdateRangeAsync(List<TEntity> entities)
    {
        Repository.UpdateRangeAsync(entities);
        var task = UnitOfWork.Complete();
        return task;
    }

    public virtual async Task<int> DeleteAsync(string id)
    {
        var row = await Repository.GetByIdAsync(id);
        Repository.Delete(row);
        var task = await UnitOfWork.Complete();
        return task;
    }

    public virtual async Task<int> DeleteRangeAsync(List<TEntity> entities)
    {
        Repository.DeleteRangeAsync(entities);
        var task = await UnitOfWork.Complete();
        return task;
    }

    public virtual async Task<int> DeleteByEntityAsync(TEntity entity)
    {
        Repository.Delete(entity);
        var task = await UnitOfWork.Complete();
        return task;
    }
}