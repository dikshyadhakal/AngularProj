using System;
using Application.Models.Request;
using FluentValidation;

namespace Application.Validators;

public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
{
    public RegisterRequestValidator()
    {
         RuleFor(x => x.Email)
        .NotEmpty().WithMessage("Email is required")
        .EmailAddress().WithMessage("Email  is not valid");

        RuleFor(x=> x.Password)
        .NotEmpty().WithMessage("Password is required")
        .MinimumLength(6).WithMessage("Length of password should be atleast 6 characters long.");

        RuleFor(x=> x.Username)
        .NotEmpty().WithMessage("UserNamme is required");  
}
}
