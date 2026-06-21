namespace RestaurantOrderQueueApi.Api.DTOs.Pedido;

public class CriarPedidoDto
{
    public string ClienteNome { get; set; }
    public string Descricao { get; set; }
    public bool ClientePrioritario { get; set; }
    public bool Delivery { get; set; }
    public int TempoPreparo { get; set; }
    public int Prioridade { get; set; }
}