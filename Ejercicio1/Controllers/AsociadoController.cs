using Ejercicio1.Models;
using Ejercicio1.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ejercicio1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsociadosController : ControllerBase
    {
        private readonly AsociadoService _asociadoService;

        public AsociadosController(AsociadoService asociadoService)
        {
            _asociadoService = asociadoService;
        }

        // Obtener todos los asociados
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Asociado>>> GetAsociados()
        {
            var asociados = await _asociadoService.GetAllAsociadosAsync();
            return Ok(asociados);
        }

        // Obtener un asociado por ID
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

        // Crear un nuevo asociado
        [HttpPost]
        public async Task<ActionResult<Asociado>> PostAsociado(Asociado asociado)
        {
            var createdAsociado = await _asociadoService.CreateAsociadoAsync(asociado);
            return CreatedAtAction(nameof(GetAsociado), new { id = createdAsociado.AsociadoId }, createdAsociado);
        }

        // Actualizar un asociado existente
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

        // Eliminar un asociado
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
