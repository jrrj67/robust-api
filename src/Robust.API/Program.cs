using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Robust.API.ViewModels;
using Robust.Domain.Entities;
using Robust.Infra.Context;
using Robust.Infra.Repositories.Users;
using Robust.Services.Dtos;
using Robust.Services.Services.Users;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Context

builder.Services.AddDbContext<RobustContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("Default")),
    ServiceLifetime.Transient);

#endregion

#region AutoMapper

var autoMapperConfig = new MapperConfiguration(cfg =>
{
    cfg.CreateMap<User, UserDto>().ReverseMap();
    cfg.CreateMap<CreateUserViewModel, UserDto>().ReverseMap();
});

builder.Services.AddSingleton(autoMapperConfig.CreateMapper());

#endregion

#region DI

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

#endregion

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
