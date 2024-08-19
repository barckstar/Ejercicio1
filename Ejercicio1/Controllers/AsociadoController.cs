using Ejercicio1.Interfaces;
using Ejercicio1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ejercicio1.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AsociadosController : ControllerBase
    {
        private readonly IAsociadoService _asociadoService;

        public AsociadosController(IAsociadoService asociadoService)
        {
            _asociadoService = asociadoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Asociado>>> GetAsociados()
        {
            var asociados = await _asociadoService.GetAllAsociadosAsync();
            return Ok(asociados);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Asociado>> GetAsociado(int id)
        {
            var asociado = await _asociadoService.GetAsociadoByIdAsync(id);

            if (asociado == null)
            {
                return NotFound();
            }

            return Ok(asociado);
        }

        [HttpPost]
        public async Task<ActionResult<Asociado>> PostAsociado(Asociado asociado)
        {
            var createdAsociado = await _asociadoService.CreateAsociadoAsync(asociado);
            return CreatedAtAction(nameof(GetAsociado), new { id = createdAsociado.AsociadoId }, createdAsociado);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsociado(int id, Asociado asociado)
        {
            if (id != asociado.AsociadoId)
            {
                return BadRequest();
            }

            var updatedAsociado = await _asociadoService.UpdateAsociadoAsync(asociado);

            if (updatedAsociado == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsociado(int id)
        {
            var result = await _asociadoService.DeleteAsociadoAsync(id);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
