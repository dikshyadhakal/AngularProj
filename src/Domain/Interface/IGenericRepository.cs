using System;

namespace Domain.Interface;

public interface IGenericRepository<TEntity> where TEntity : class
{
    Task<TEntity?>GetByIdAsync(int id);
    Task<List<TEntity>>GetAllAsync(int id);
    Task<TEntity>AddAsync(TEntity entity);
    TEntity Update(TEntity entity);
    void Delete(TEntity entity);


}

