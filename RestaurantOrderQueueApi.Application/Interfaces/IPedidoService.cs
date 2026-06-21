using RestaurantOrderQueueApi.Domain.Entities;

namespace RestaurantOrderQueueApi.Application.Interfaces;

public interface IPedidoService
{
    Task<Pedido> CriarAsync(Pedido pedido);
    Task<List<Pedido>> ListarAsync();
    Task<Pedido?> BuscarAsync(Guid id);
    Task AtualizarAsync(Pedido pedido);
    Task ExcluirAsync(Guid id);
}