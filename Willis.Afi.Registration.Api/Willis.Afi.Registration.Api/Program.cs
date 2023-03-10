using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Willis.Afi.Registration.Api.DataAccess;
using Willis.Afi.Registration.Api.ErrorHandling;
using Willis.Afi.Registration.Api.Models;
using Willis.Afi.Registration.Api.Services;
using Willis.Afi.Registration.Api.Services.Interfaces;
using Willis.Afi.Registration.Api.Services.MappingProfiles;
using Willis.Afi.Registration.Api.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<ICustomerService, CustomerService>();
builder.Services.AddScoped<IValidator<RegisterRequest>, RegisterRequestValidator>();

//Setup AutoMapper
builder.Services.AddSingleton(AutoMapperConfig.Initialize());

//Add DB Context
builder.Services.AddDbContext<DataContext>(
    options => options.UseSqlite(builder.Configuration.GetConnectionString("RegistrationDatabase"),
    sqlOptions => sqlOptions.MigrationsAssembly("Willis.Afi.Registration.Api.DataAccess")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ConfigureExceptionHandler(app.Logger);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
public partial class Program { }