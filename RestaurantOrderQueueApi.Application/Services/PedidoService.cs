using RestaurantOrderQueueApi.Application.Interfaces;
using RestaurantOrderQueueApi.Domain.Entities;
using RestaurantOrderQueueApi.Domain.Interfaces;
using RestaurantOrderQueueApi.Domain.Enums;

namespace RestaurantOrderQueueApi.Application.Services;

public class PedidoService : IPedidoService
{
    private readonly IPedidoRepository _repository;

    public PedidoService(IPedidoRepository repository)
    {
        _repository = repository;
    }

    public async Task<Pedido> CriarAsync(Pedido pedido)
    {
        pedido.Status = StatusPedido.Pendente;
        pedido.DataCriacao = DateTime.Now;
        pedido.ValorTotal = CalcularValor(pedido);

        return await _repository.AdicionarAsync(pedido);
    }

    public async Task<List<Pedido>> ListarAsync()
    {
        return await _repository.ListarAsync();
    }

    public async Task<Pedido?> BuscarAsync(Guid id)
    {
        return await _repository.BuscarPorIdAsync(id);
    }

    public async Task AtualizarAsync(Pedido pedido)
    {
        var existente = await _repository.BuscarPorIdAsync(pedido.Id);

        if (existente == null)
            return;

        existente.ClienteNome = pedido.ClienteNome;
        existente.Descricao = pedido.Descricao;
        existente.ClientePrioritario = pedido.ClientePrioritario;
        existente.Delivery = pedido.Delivery;
        existente.TempoPreparo = pedido.TempoPreparo;
        existente.Prioridade = pedido.Prioridade;

        existente.ValorTotal = CalcularValor(existente);

        await _repository.AtualizarAsync(existente);
    }

    public async Task ExcluirAsync(Guid id)
    {
        var pedido = await _repository.BuscarPorIdAsync(id);

        if (pedido != null)
        {
            pedido.Status = StatusPedido.Cancelado;
            await _repository.AtualizarAsync(pedido);
        }
    }

    private decimal CalcularValor(Pedido pedido)
    {
        return pedido.TempoPreparo * 2;
    }
}