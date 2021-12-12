using System.Reflection;
using DataService.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Database")));

var app = builder.Build();

var database = app.Services.CreateScope().ServiceProvider.GetService<DatabaseContext>();
await database!.Database.MigrateAsync();
database.Dispose();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();