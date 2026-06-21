using Microsoft.AspNetCore.Mvc;
using RestaurantOrderQueueApi.Api.DTOs.Pedido;
using RestaurantOrderQueueApi.Application.Interfaces;
using RestaurantOrderQueueApi.Domain.Entities;

namespace RestaurantOrderQueueApi.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoService _service;

        public PedidoController(IPedidoService service)
        {
            _service = service;
        }

        private static PedidoResponseDto ToDto(Pedido pedido)
        {
            return new PedidoResponseDto
            {
                Id = pedido.Id,
                ClienteNome = pedido.ClienteNome,
                Descricao = pedido.Descricao,
                ClientePrioritario = pedido.ClientePrioritario,
                Delivery = pedido.Delivery,
                TempoPreparo = pedido.TempoPreparo,
                Prioridade = pedido.Prioridade,
                Status = pedido.Status.ToString()
            };
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PedidoResponseDto>> GetById(Guid id)
        {
            var pedido = await _service.BuscarAsync(id);

            if (pedido == null)
                return NotFound();

            return Ok(ToDto(pedido));
        }

        [HttpPost]
        public async Task<ActionResult<PedidoResponseDto>> Criar(CriarPedidoDto dto)
        {
            var pedido = new Pedido
            {
                ClienteNome = dto.ClienteNome,
                Descricao = dto.Descricao,
                ClientePrioritario = dto.ClientePrioritario,
                Delivery = dto.Delivery,
                TempoPreparo = dto.TempoPreparo,
                Prioridade = dto.Prioridade
            };

            var resultado = await _service.CriarAsync(pedido);

            return CreatedAtAction(
                nameof(GetById),
                new { id = resultado.Id },
                ToDto(resultado)
            );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(Guid id, AtualizarPedidoDto dto)
        {
            var pedido = new Pedido
            {
                Id = id,
                ClienteNome = dto.ClienteNome,
                Descricao = dto.Descricao,
                ClientePrioritario = dto.ClientePrioritario,
                Delivery = dto.Delivery,
                TempoPreparo = dto.TempoPreparo,
                Prioridade = dto.Prioridade
            };

            await _service.AtualizarAsync(pedido);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Excluir(Guid id)
        {
            await _service.ExcluirAsync(id);

            return NoContent();
        }
    }
}