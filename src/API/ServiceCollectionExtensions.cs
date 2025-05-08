using System;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace API;

public static class ServiceCollectionExtensions
{
   public static IServiceCollection AddWebServices(this IServiceCollection services, IConfiguration configuration) 
   {
    services.AddSwaggerGen(options =>{
    //update name of doc
    options.SwaggerDoc("v1", new OpenApiInfo{Title = "Angular Blog API", Version = "v1"});
    //update name of api
    options.SwaggerGeneratorOptions.DocumentFilters.Add(new LowerCaseDocumentFilter());
    //configure the JWT authentication
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"

    });
    //Add JWT bearer Security Requirements
    options.AddSecurityRequirement(
        new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme{
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    },
                    Scheme = "oauth2",
                    Name = "Bearer",
                    In = ParameterLocation.Header
            },
            []

            }
        });

    });

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey
                    (Encoding.UTF8.GetBytes(configuration["jwt:key"])),
                    ClockSkew = TimeSpan.Zero//if not than the token expires in 5 min default time.

                };
            });   
    return services;   
   }

}
