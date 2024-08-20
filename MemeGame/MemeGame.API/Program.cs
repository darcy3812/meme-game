using MemeGame.API;
using MemeGame.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddAPI();

var app = builder.Build();
app.UseCors(opt =>
{
    opt
        .WithOrigins(["http://localhost:5173", "http://localhost:8080", "http://localhost:8081"])
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials();
});
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ApplyMigrations();
}

app.UseAPI();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
