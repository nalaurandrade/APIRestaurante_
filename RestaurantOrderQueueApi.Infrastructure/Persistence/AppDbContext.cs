using Microsoft.EntityFrameworkCore;
using RestaurantOrderQueueApi.Domain.Entities;

namespace RestaurantOrderQueueApi.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Pedido> Pedidos { get; set; }
}