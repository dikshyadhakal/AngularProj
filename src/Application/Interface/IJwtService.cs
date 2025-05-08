 using System;
using Domain.Entities;

namespace Application.Interface;

public interface IJwtService
{
    Task<string> GenerateTokenAsync(User user);

}
