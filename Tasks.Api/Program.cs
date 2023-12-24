using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Tasks.Api.Models;
using Tasks.Domain.Interfaces;
using Tasks.Domain.Interfaces.Generics;
using Tasks.Domain.Interfaces.Services;
using Tasks.Domain.Services;
using Tasks.Entities.Entities;
using Tasks.Infra.Configuration;
using Tasks.Infra.Repository.Generics;
using Tasks.Infra.Repository.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ContextBase>(options =>
              options.UseSqlite(
                  builder.Configuration.GetConnectionString("PokeDB")));


builder.Services.AddSingleton(typeof(IGeneric<>), typeof(RepositoryGeneric<>));
builder.Services.AddSingleton<ITarefa, RepositoryTarefa>();

builder.Services.AddSingleton<IServiceTarefa, ServiceTarefa>();

var config = new AutoMapper.MapperConfiguration(c => 
{
    c.CreateMap<TarefaViewModel, Tarefa>();
    c.CreateMap<Tarefa, TarefaViewModel>();
});
IMapper mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
