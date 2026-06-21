using RestaurantOrderQueueApi.Domain.Entities;
using RestaurantOrderQueueApi.Domain.Interfaces;

namespace RestaurantOrderQueueApi.Application.UseCases;

public class GetPedidoUseCase
{
    private readonly IPedidoRepository _repository;

    public GetPedidoUseCase(IPedidoRepository repository)
    {
        _repository = repository;
    }

    public async Task<Pedido?> ExecuteAsync(Guid id)
    {
        return await _repository.BuscarPorIdAsync(id);
    }
}