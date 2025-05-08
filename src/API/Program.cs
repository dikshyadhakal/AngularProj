using System.Net.Http.Headers;
using System.Text;
using API;
using Application.Extention;
using Infrastructure.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();

builder.Services.AddWebServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
  
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();

public class LowerCaseDocumentFilter : IDocumentFilter
{
    public void Apply (OpenApiDocument swaggerDoc, DocumentFilterContext context)
    {
        //get the path
        var paths = swaggerDoc.Paths.ToDictionary(
            path =>path.Key.ToLowerInvariant(),
        path => swaggerDoc.Paths[path.Key]);

        //add the path in swagger

        swaggerDoc.Paths = new OpenApiPaths();
        foreach(var pathItem in paths)
        {
            swaggerDoc.Paths.Add(pathItem.Key, pathItem.Value);

        }

    }
}