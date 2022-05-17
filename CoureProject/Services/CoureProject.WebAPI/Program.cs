using CoureProject.DAL;
using CoureProject.DAL.Context;
using CoureProject.DAL.Repositories;
using CoureProject.Interfaces;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
var connection_type = builder.Configuration["DataBase"];
var connection_string = builder.Configuration.GetConnectionString(connection_type);

switch (connection_type)
{
    case "SQLiteServer":
        services.AddDbContext<CoureProjectDB>(opt => opt.UseSqlite(connection_string, o => o.MigrationsAssembly("CoureProject.DAL.SQLiteServer")));
        break;
}


services.AddTransient<DbInitializer>();
services.AddScoped(typeof(IRepositoryAsync<>), typeof(EntityRepository<>));

// Add services to the container.

services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
IServiceCollection serviceCollection = services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

var app = builder.Build();

using(var scope = app.Services.CreateScope())
{
    var initializer = scope.ServiceProvider.GetRequiredService<DbInitializer>();
    await initializer.InitializeDBAsync(RemoveBefore: false);
}

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
