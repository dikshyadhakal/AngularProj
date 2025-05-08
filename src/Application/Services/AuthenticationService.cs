using System;
using System.Net;
using Application.Interface;
using Application.Models;
using Application.Models.Request;
using Application.Validators;
using Domain.Entities;
using Domain.Interface;

namespace Application.Services;

public class AuthenticationService(IUnitOfWork unitOfWork, 
IUserRepository userRepository, 
LoginRequestValidator loginRequestValidator,
RegisterRequestValidator registerRequestValidator,
IJwtService jwtService) : IAuthenticationService
{


    public async Task<Result> LoginAsync(LoginRequest loginRequest)
    {
        var validationResult = await loginRequestValidator.ValidateAsync(loginRequest);
        if(!validationResult.IsValid)
        {
            var errors = validationResult.Errors.Select(a=>a.ErrorMessage);
            return Result.Failure(AuthenticationError.CreateInvalidLoginRequestError(errors));
        }

        var (email, password)= (loginRequest);
        var user = await userRepository.GetUserByEmailAsync(email);
        if(user is null)
        {
            return Result.Failure(AuthenticationError.UserNotFound);
        }
        if(user.Password != password)
        {
            return Result.Failure(AuthenticationError.InvalidPassword);
        }
        var token = await jwtService.GenerateTokenAsync(user);
        var result = new {
            Token = token,
            Username = user.Username
        };
        return Result.Success(result);

    }

    public async Task<Result> RegisterAsync(RegisterRequest registerRequest)
    {
        var validationResult = await registerRequestValidator.ValidateAsync(registerRequest);
        if(!validationResult.IsValid)
        {
                var errors = validationResult.Errors.Select(a=>a.ErrorMessage);
            return Result.Failure(AuthenticationError.CreateInvalidLoginRequestError(errors));
        }

        var userExist = await userRepository.GetUserByEmailAsync(registerRequest.Email);

        if (userExist is not null)
         {
           return Result.Failure(AuthenticationError.UserAlreadyExist);
         }

        var user = new User
        {
            Email = registerRequest.Email,
            Password = registerRequest.Password,
            Username = registerRequest.Username
        };
        await userRepository.AddAsync(user);
        await unitOfWork.CommitAsync();
        return Result.Success("User registered successfully!");
    }
}
