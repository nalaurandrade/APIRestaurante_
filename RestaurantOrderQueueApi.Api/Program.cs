using Microsoft.EntityFrameworkCore;
using RestaurantOrderQueueApi.Application.Interfaces;
using RestaurantOrderQueueApi.Application.Services;
using RestaurantOrderQueueApi.Domain.Interfaces;
using RestaurantOrderQueueApi.Infrastructure.Persistence;
using RestaurantOrderQueueApi.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Controllers
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// DI (Dependency Injection)
builder.Services.AddScoped<IPedidoRepository, PedidoRepository>();
builder.Services.AddScoped<IPedidoService, PedidoService>();

var app = builder.Build();

// Swagger UI
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "RestaurantOrderQueueApi v1");
        c.RoutePrefix = string.Empty; // abre direto no browser
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();