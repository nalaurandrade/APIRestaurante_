using Microsoft.EntityFrameworkCore;
using RestaurantOrderQueueApi.Domain.Entities;
using RestaurantOrderQueueApi.Domain.Interfaces;
using RestaurantOrderQueueApi.Infrastructure.Persistence;

namespace RestaurantOrderQueueApi.Infrastructure.Repositories;

public class PedidoRepository : IPedidoRepository
{
    private readonly AppDbContext _context;

    public PedidoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Pedido> AdicionarAsync(Pedido pedido)
    {
        _context.Pedidos.Add(pedido);
        await _context.SaveChangesAsync();
        return pedido;
    }

    public async Task<Pedido?> BuscarPorIdAsync(Guid id)
    {
        return await _context.Pedidos.FindAsync(id);
    }

    public async Task<List<Pedido>> ListarAsync()
    {
        return await _context.Pedidos.ToListAsync();
    }

    public async Task<List<Pedido>> ListarPaginadoAsync(int page, int size)
    {
        return await _context.Pedidos
            .Skip((page - 1) * size)
            .Take(size)
            .ToListAsync();
    }

    public async Task<List<Pedido>> BuscarFiltroAsync(string? descricao)
    {
        return await _context.Pedidos
            .Where(p => descricao == null || p.Descricao.Contains(descricao))
            .ToListAsync();
    }

    public async Task AtualizarAsync(Pedido pedido)
    {
        _context.Pedidos.Update(pedido);
        await _context.SaveChangesAsync();
    }
}