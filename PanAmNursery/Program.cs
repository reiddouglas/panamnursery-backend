using Microsoft.EntityFrameworkCore;
using PanAmNursery.Data;
using PanAmNursery.Repositories;
using PanAmNursery.Repositories.Interfaces;
using PanAmNursery.Services;
using PanAmNursery.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
       .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
       .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true)
       .AddEnvironmentVariables();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
Console.WriteLine($"[DEBUG] Connection string found? {connectionString != null}");
// Add services to the container.

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<DatabaseContext>(options => { options.UseSqlServer(connectionString); });

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
