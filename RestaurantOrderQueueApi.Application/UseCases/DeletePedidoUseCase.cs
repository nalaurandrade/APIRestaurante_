using RestaurantOrderQueueApi.Domain.Interfaces;
using RestaurantOrderQueueApi.Domain.Enums;

namespace RestaurantOrderQueueApi.Application.UseCases
{
    public class DeletePedidoUseCase
    {
        private readonly IPedidoRepository _repository;

        public DeletePedidoUseCase(IPedidoRepository repository)
        {
            _repository = repository;
        }

        public async Task ExecuteAsync(Guid id)
        {
            var pedido = await _repository.BuscarPorIdAsync(id);

            if (pedido == null)
                return;

            pedido.Status = StatusPedido.Cancelado;

            await _repository.AtualizarAsync(pedido);
        }
    }
}