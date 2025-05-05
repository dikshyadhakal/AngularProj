using Domain.Entities;
using Domain.Interface;
using Infrastructure.persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.persistence.Repositories;

public class UserRepository(ApplicationDbContext applicationDbContext) : GenericRepository<User>(applicationDbContext), IUserRepository
{
    public async Task<User?> GetUserByEmailAsync(string Email)
    {
       return await applicationDbContext .Users.FirstOrDefaultAsync(x => x.Email == Email);
    }

    public async Task<List<string>> GetUserRolesByEmail(string Email)
    {
        return await applicationDbContext.Users
                .Where(x => x.Email == Email)
                .SelectMany(x => x.UserRoles)
                .Select(x => x.Role.Name)
                .ToListAsync();
    }
}
