using System;
using Application.Common.Results;

namespace Application;

public static class AuthenticationError
{
    public static Error InvalidRegisterRequest => new(ErrorTypeConstant.ValidationError, "Invalid register request");
    public static Error UserAlreadyExist => new(ErrorTypeConstant.ValidationError, "User already exist");

    public static Error InvalidLoginRequest => new(ErrorTypeConstant.ValidationError, "Invalid login request");
      public static Error UserNotFound => new(ErrorTypeConstant.NotFound, "User Not Found");
      public static Error InvalidPassword => new(ErrorTypeConstant.ValidationError, "Invalid password");
      public static Error CreateInvalidLoginRequestError(IEnumerable<string> errors)=>
      new(ErrorTypeConstant.ValidationError, string.Join(",", errors));
}
