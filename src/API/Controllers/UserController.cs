using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class UserController:BaseApiController
{
    [Authorize]//executes the jwt token verification.
    [HttpGet]

    public string[] GetUser()
    {
        return new[]
        {
            "User 1","User 2","User 3","User 4", "User 5"

        };
    }

}
