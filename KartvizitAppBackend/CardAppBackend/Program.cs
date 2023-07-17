using CardAppBackend.MapperProfile;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Hosting;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Mapster
var assembly = typeof(Program).Assembly;
var mapperProfileTypes = assembly.GetTypes()
           .Where(t => t.IsClass && t.Name.EndsWith("MapperProfile"));
foreach (var mapperProfileType in mapperProfileTypes)
{
    var mapperProfileInstance = Activator.CreateInstance(mapperProfileType);
    builder.Services.AddSingleton(mapperProfileType, mapperProfileInstance);
}
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder => builder
    .AllowAnyOrigin()
       .AllowAnyMethod()
          .AllowAnyHeader());


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
