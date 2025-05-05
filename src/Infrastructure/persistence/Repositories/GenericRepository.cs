using System;
using Domain.Interface;
using Infrastructure.persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.persistence.Repositories;

public class GenericRepository<TEntity>(ApplicationDbContext context) : IGenericRepository<TEntity> where TEntity : class
{
    internal readonly DbSet<TEntity> DbSet = context.Set<TEntity>();
    public async Task<TEntity> AddAsync(TEntity entity)
    {
        var entry = await DbSet.AddAsync(entity);
        return entry.Entity;
    }

    public void Delete(TEntity entity)
    {
        DbSet.Remove(entity);
    }

    public async Task<List<TEntity>> GetAllAsync(int id)
    {
        return await DbSet.ToListAsync();
    }

    public async Task<TEntity?> GetByIdAsync(int id)
    {
        return await DbSet.FindAsync(id);
    }
    public TEntity Update(TEntity entity)
    {
        var entry = DbSet.Update(entity);
        return entry.Entity;
    }
}
