using System;
using Application.Models;
using Application.Models.Request;

namespace Application.Interface;

public interface IAuthenticationService
{
    Task<Result>RegisterAsync(RegisterRequest registerRequest);
    Task<Result>LoginAsync(LoginRequest loginRequest);

}
