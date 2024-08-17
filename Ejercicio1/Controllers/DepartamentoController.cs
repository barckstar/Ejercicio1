using Ejercicio1.Models;
using Ejercicio1.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ejercicio1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentosController : ControllerBase
    {
        private readonly DepartamentoService _departamentoService;

        public DepartamentosController(DepartamentoService departamentoService)
        {
            _departamentoService = departamentoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Departamento>>> GetDepartamentos()
        {
            var departamentos = await _departamentoService.GetAllDepartamentosAsync();
            return Ok(departamentos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Departamento>> GetDepartamento(int id)
        {
            var departamento = await _departamentoService.GetDepartamentoByIdAsync(id);

            if (departamento == null)
            {
                return NotFound();
            }

            return Ok(departamento);
        }

        [HttpPost]
        public async Task<ActionResult<Departamento>> PostDepartamento(Departamento departamento)
        {
            var createdDepartamento = await _departamentoService.CreateDepartamentoAsync(departamento);
            return CreatedAtAction(nameof(GetDepartamento), new { id = createdDepartamento.DepartamentoId }, createdDepartamento);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartamento(int id, Departamento departamento)
        {
            if (id != departamento.DepartamentoId)
            {
                return BadRequest();
            }

            var updatedDepartamento = await _departamentoService.UpdateDepartamentoAsync(departamento);

            if (updatedDepartamento == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartamento(int id)
        {
            var result = await _departamentoService.DeleteDepartamentoAsync(id);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
