using names_ms.Application.Interfaces;
using names_ms.Application.Services;
using names_ms.Domain.Filters;
using names_ms.Infrastructure.Repositories;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Configura Serilog
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

// Reemplaza el logger por defecto con Serilog
builder.Host.UseSerilog();

// Add services to the container.
builder.Services.AddScoped<INameRepository, NameRepository>();
builder.Services.AddScoped<IFilterStrategy, GenderFilter>();
builder.Services.AddScoped<IFilterStrategy, NameStartsWithFilter>();
builder.Services.AddScoped<INameService, NameService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseMiddleware<ExceptionHandlerMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();