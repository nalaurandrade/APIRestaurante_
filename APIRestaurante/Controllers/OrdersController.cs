using Microsoft.AspNetCore.Mvc;

namespace RestaurantOrderQueueApi.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PedidoController : ControllerBase
{
    private readonly PedidoService _service;

    public PedidoController(PedidoService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Criar([FromBody] CriarPedidoDto dto)
        => Ok(await _service.CriarAsync(dto));

    [HttpGet("{id}")]
    public async Task<IActionResult> Buscar(Guid id)
        => Ok(await _service.BuscarAsync(id));

    [HttpGet]
    public async Task<IActionResult> Listar([FromQuery] int page = 1, [FromQuery] int size = 10)
        => Ok(await _service.ListarAsync());

    [HttpGet("buscar")]
    public async Task<IActionResult> BuscarFiltro([FromQuery] string? cpf, [FromQuery] string? descricao)
        => Ok(await _service.BuscarFiltro(cpf, descricao));

    [HttpPut("{id}")]
    public async Task<IActionResult> Atualizar(Guid id, [FromBody] AtualizarPedidoDto dto)
        => Ok(await _service.AtualizarAsync(id, dto));

    [HttpDelete("{id}")]
    public async Task<IActionResult> Cancelar(Guid id)
        => Ok(await _service.CancelarAsync(id));
}