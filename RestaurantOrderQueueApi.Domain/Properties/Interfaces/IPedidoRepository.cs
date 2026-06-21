using RestaurantOrderQueueApi.Domain.Entities;

namespace RestaurantOrderQueueApi.Domain.Interfaces;

public interface IPedidoRepository
{
    Task<Pedido> AdicionarAsync(Pedido pedido);
    Task<Pedido?> BuscarPorIdAsync(Guid id);
    Task<List<Pedido>> ListarAsync();
    Task AtualizarAsync(Pedido pedido);
}