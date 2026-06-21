using RestaurantOrderQueueApi.Domain.Enums;

namespace RestaurantOrderQueueApi.Domain.Entities;

public class Pedido
{
    public Guid Id { get; set; }
    public string ClienteNome { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public bool ClientePrioritario { get; set; }
    public bool Delivery { get; set; }
    public int TempoPreparo { get; set; }
    public int Prioridade { get; set; }

    public DateTime DataCriacao { get; set; }
    public decimal ValorTotal { get; set; }

    public StatusPedido Status { get; set; } = StatusPedido.Pendente;
}