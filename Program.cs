using GerenciadorDeBiblioteca.API.Persistence;
using GerenciadorDeBiblioteca.Application;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddDbContext<GerenciadorDeBibliotecaDbContext>(o => o.UseInMemoryDatabase("GerenciamentoDeBibliotecaDb"));

var connectionString = builder.Configuration.GetConnectionString("GerenciadorDeBibliotecaCs");

builder.Services.AddDbContext<GerenciadorDeBibliotecaDbContext>(o => o.UseSqlServer(connectionString));

builder.Services
    .AddApplication();

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
