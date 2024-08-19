using Ejercicio1.Interfaces;
using Ejercicio1.Models;
using Microsoft.EntityFrameworkCore;

namespace Ejercicio1.Services
{
    public class SalarioService : ISalarioService
    {
        private readonly EjercicioDbContext _context;

        public SalarioService(EjercicioDbContext context)
        {
            _context = context;
        }
        // Aumentar salario para todos los asociados
        public async Task<IEnumerable<Asociado>> AumentarSalarioTodosAsync(decimal porcentajeAumento)
        {
            var asociados = await _context.Asociados.ToListAsync();
            asociados.ForEach(a => a.Salario *= 1 + (porcentajeAumento / 100));
            await _context.SaveChangesAsync();
            return asociados;
        }

        // Aumentar salario para asociados de un departamento específico
        public async Task<IEnumerable<Asociado>> AumentarSalarioDepartamentoAsync(int departamentoId, decimal porcentajeAumento)
        {
            var asociados = await _context.Asociados.Where(a => a.DepartamentoId == departamentoId).ToListAsync();
            asociados.ForEach(a => a.Salario *= 1 + (porcentajeAumento / 100));
            await _context.SaveChangesAsync();
            return asociados;
        }

        // Aumentar salario para un asociado específico
        public async Task<Asociado?> AumentarSalarioAsociadoAsync(int asociadoId, decimal porcentajeAumento)
        {
            var asociado = await _context.Asociados.FirstOrDefaultAsync(a => a.AsociadoId == asociadoId);

            if (asociado == null)
            {
                return null;
            }

            asociado.Salario *= 1 + (porcentajeAumento / 100);
            await _context.SaveChangesAsync();
            return asociado;
        }

        // Decrementar salario para todos los asociados
        public async Task<IEnumerable<Asociado>> DecrementarSalarioTodosAsync(decimal porcentajeDecremento)
        {
            var asociados = await _context.Asociados.ToListAsync();
            asociados.ForEach(a => a.Salario *= 1 - (porcentajeDecremento / 100));
            await _context.SaveChangesAsync();
            return asociados;
        }

        // Decrementar salario para asociados de un departamento específico
        public async Task<IEnumerable<Asociado>> DecrementarSalarioDepartamentoAsync(int departamentoId, decimal porcentajeDecremento)
        {
            var asociados = await _context.Asociados.Where(a => a.DepartamentoId == departamentoId).ToListAsync();
            asociados.ForEach(a => a.Salario *= 1 - (porcentajeDecremento / 100));
            await _context.SaveChangesAsync();
            return asociados;
        }

        // Decrementar salario para un asociado específico
        public async Task<Asociado?> DecrementarSalarioAsociadoAsync(int asociadoId, decimal porcentajeDecremento)
        {
            var asociado = await _context.Asociados.FirstOrDefaultAsync(a => a.AsociadoId == asociadoId);

            if (asociado == null)
            {
                return null;
            }

            asociado.Salario *= 1 - (porcentajeDecremento / 100);
            await _context.SaveChangesAsync();
            return asociado;
        }
    }
}
