using EmployeeManagementSystemApi.Logic;
using EmployeeManagementSystemDb.Command;
using EmployeeManagementSystemDb.Models;
using Logic.Utils;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<EmployeeManagementContext>();
var dbContextOptionsBuilder = new DbContextOptionsBuilder<EmployeeManagementContext>();
dbContextOptionsBuilder.UseSqlServer("Database=EmployeeManagement;Server=Laptop-10JSI7Q1;Trusted_Connection=True;Encrypt=false");
builder.Services.AddMvc();
//builder.Services.AddDbContext<DbContextFactory>();

builder.Services.AddScoped<UnitOfWork>();
builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();
builder.Services.AddScoped<SessionFactory>();
builder.Services.AddSingleton<ValidateRequest>();
builder.Services.AddScoped<EmployeeService>();
builder.Services.AddScoped<Service>();
builder.Services.AddSingleton<Utils>();


var app = builder.Build();

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
