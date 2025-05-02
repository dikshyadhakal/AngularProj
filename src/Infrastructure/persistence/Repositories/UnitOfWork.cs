using System;
using Domain.Interface;
using Infrastructure.persistence.Context;

namespace Infrastructure.persistence.Repositories;

public class UnitOfWork(ApplicationDbContext context) : IUnitOfWork
{
    public void Commit()
    {
       context.SaveChanges();
    }

    public async Task CommitAsync()
    {
        await context.SaveChangesAsync();
    }
}
