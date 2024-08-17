using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinimalApi.Domain.Interfaces;
using MinimalApi.Domain.Services;
using MinimalApi.DTOs;
using MinimalApi.Infraestructure.Db;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IAdministratorService, AdministratorService>();

builder.Services.AddDbContext<MinimalApi.Infraestructure.Db.DataBaseContext>(options => 
    options.UseMySql(
        builder.Configuration.GetConnectionString("mysql"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("mysql"))
)
);
// builder.Services.AddScoped

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapPost("/login", handler: ([FromBody]LoginDTO loginDTO, IAdministratorService administratorService) => {
    if(administratorService.Login(loginDTO) != null){
        return Results.Ok("Login com sucesso");
    }
    else
        return Results.Unauthorized();
});




app.Run();