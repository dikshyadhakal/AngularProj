using System;
using System.Runtime.CompilerServices;
using Domain.Entities;

namespace Domain.Interface;

public interface IUserRepository : IGenericRepository<User>
{
    Task<User?>GetUserByEmailAsync(string Email);

    Task<List<string>>GetUserRolesByEmailAsync(string Email);

}
