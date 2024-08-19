using Ejercicio1.Interfaces;
using Ejercicio1.Models;
using Microsoft.EntityFrameworkCore;

namespace Ejercicio1.Services
{
    public class AsociadoService : IAsociadoService
    {
        private readonly EjercicioDbContext _context;

        public AsociadoService(EjercicioDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Asociado>> GetAllAsociadosAsync() => await _context.Asociados.ToListAsync();

        public async Task<Asociado> GetAsociadoByIdAsync(int id) => await _context.Asociados.FirstOrDefaultAsync(a => a.AsociadoId == id);

        public async Task<Asociado> CreateAsociadoAsync(Asociado asociado)
        {
            _context.Asociados.Add(asociado);
            await _context.SaveChangesAsync();
            return asociado;
        }

        public async Task<Asociado?> UpdateAsociadoAsync(Asociado asociado)
        {
            var existingAsociado = await _context.Asociados.FirstOrDefaultAsync(a => a.AsociadoId == asociado.AsociadoId);

            if (existingAsociado == null)
            {
                return null;
            }

            existingAsociado.Nombre = asociado.Nombre;
            existingAsociado.Salario = asociado.Salario;
            existingAsociado.DepartamentoId = asociado.DepartamentoId;

            _context.Asociados.Update(existingAsociado);
            await _context.SaveChangesAsync();
            return existingAsociado;
        }

        public async Task<bool> DeleteAsociadoAsync(int id)
        {
            var asociado = await _context.Asociados.FirstOrDefaultAsync(a => a.AsociadoId == id);

            if (asociado == null)
            {
                return false;
            }

            _context.Asociados.Remove(asociado);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
