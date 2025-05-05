using Application;
using Application.Common.Results;
using Application.Interface;
using Application.Models;
using Application.Models.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Template;

namespace API.Controllers;

public class AuthController(IAuthenticationService autheticationService):BaseApiController
{
    [HttpPost("register")]
    public async Task<IResult>Register(RegisterRequest registerRequest)
    {
        var response = await autheticationService.RegisterAsync(registerRequest);
       return response.ToHttpResponse();

    }

     [HttpPost("Login")]
    public async Task<IResult>Login(LoginRequest loginRequest)
    {
        var response = await autheticationService.LoginAsync(loginRequest);
        return response.ToHttpResponse();
    }
}
