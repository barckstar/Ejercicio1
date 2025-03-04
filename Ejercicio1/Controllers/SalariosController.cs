﻿using Ejercicio1.Interfaces;
using Ejercicio1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ejercicio1.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SalariosController : ControllerBase
    {
        private readonly ISalarioService _salarioService;

        public SalariosController(ISalarioService salarioService)
        {
            _salarioService = salarioService;
        }

        // Endpoint para aumentar el salario de todos los asociados
        [HttpPost("AumentarTodos")]
        public async Task<ActionResult<IEnumerable<Asociado>>> AumentarSalarioTodos([FromQuery] decimal porcentajeAumento)
        {
            if (porcentajeAumento <= 0)
            {
                return BadRequest("El porcentaje de aumento debe ser mayor a 0.");
            }

            var asociados = await _salarioService.AumentarSalarioTodosAsync(porcentajeAumento);
            return Ok(asociados);
        }

        // Endpoint para aumentar el salario de asociados de un departamento específico
        [HttpPost("AumentarDepartamento/{departamentoId}")]
        public async Task<ActionResult<IEnumerable<Asociado>>> AumentarSalarioDepartamento(int departamentoId, [FromQuery] decimal porcentajeAumento)
        {
            if (porcentajeAumento <= 0)
            {
                return BadRequest("El porcentaje de aumento debe ser mayor a 0.");
            }

            var asociados = await _salarioService.AumentarSalarioDepartamentoAsync(departamentoId, porcentajeAumento);

            if (asociados == null || !asociados.Any())
            {
                return NotFound("No se encontraron asociados para el departamento especificado.");
            }

            return Ok(asociados);
        }

        // Endpoint para aumentar el salario de un asociado específico
        [HttpPost("AumentarAsociado/{asociadoId}")]
        public async Task<ActionResult<Asociado>> AumentarSalarioAsociado(int asociadoId, [FromQuery] decimal porcentajeAumento)
        {
            if (porcentajeAumento <= 0)
            {
                return BadRequest("El porcentaje de aumento debe ser mayor a 0.");
            }

            var asociado = await _salarioService.AumentarSalarioAsociadoAsync(asociadoId, porcentajeAumento);

            if (asociado == null)
            {
                return NotFound("Asociado no encontrado.");
            }

            return Ok(asociado);
        }

        // Endpoint para decrementar el salario de todos los asociados
        [HttpPost("DecrementarTodos")]
        public async Task<ActionResult<IEnumerable<Asociado>>> DecrementarSalarioTodos([FromQuery] decimal porcentajeDecremento)
        {
            if (porcentajeDecremento <= 0)
            {
                return BadRequest("El porcentaje de decremento debe ser mayor a 0.");
            }

            var asociados = await _salarioService.DecrementarSalarioTodosAsync(porcentajeDecremento);
            return Ok(asociados);
        }

        // Endpoint para decrementar el salario de asociados de un departamento específico
        [HttpPost("DecrementarDepartamento/{departamentoId}")]
        public async Task<ActionResult<IEnumerable<Asociado>>> DecrementarSalarioDepartamento(int departamentoId, [FromQuery] decimal porcentajeDecremento)
        {
            if (porcentajeDecremento <= 0)
            {
                return BadRequest("El porcentaje de decremento debe ser mayor a 0.");
            }

            var asociados = await _salarioService.DecrementarSalarioDepartamentoAsync(departamentoId, porcentajeDecremento);

            if (asociados == null || !asociados.Any())
            {
                return NotFound("No se encontraron asociados para el departamento especificado.");
            }

            return Ok(asociados);
        }

        // Endpoint para decrementar el salario de un asociado específico
        [HttpPost("DecrementarAsociado/{asociadoId}")]
        public async Task<ActionResult<Asociado>> DecrementarSalarioAsociado(int asociadoId, [FromQuery] decimal porcentajeDecremento)
        {
            if (porcentajeDecremento <= 0)
            {
                return BadRequest("El porcentaje de decremento debe ser mayor a 0.");
            }

            var asociado = await _salarioService.DecrementarSalarioAsociadoAsync(asociadoId, porcentajeDecremento);

            if (asociado == null)
            {
                return NotFound("Asociado no encontrado.");
            }

            return Ok(asociado);
        }
    }
}
