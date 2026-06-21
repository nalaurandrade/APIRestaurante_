using RestaurantOrderQueueApi.Domain.Entities;

namespace RestaurantOrderQueueApi.Domain.Interfaces;

public interface IPedidoRepository
{
    Task<Pedido> AdicionarAsync(Pedido pedido);
    Task<Pedido?> BuscarPorIdAsync(Guid id);
    Task<List<Pedido>> ListarAsync();

    Task<List<Pedido>> ListarPaginadoAsync(int page, int size);
    Task<List<Pedido>> BuscarFiltroAsync(string? descricao);

    Task AtualizarAsync(Pedido pedido);
}