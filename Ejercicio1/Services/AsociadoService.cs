using Ejercicio1.Models;
using Microsoft.EntityFrameworkCore;

namespace Ejercicio1.Services
{
    public class AsociadoService
    {
        private readonly EjercicioDbContext _context;

        public AsociadoService(EjercicioDbContext context)
        {
            _context = context;
        }

        // Obtener todos los asociados
        public async Task<IEnumerable<Asociado>> GetAllAsociadosAsync() => await _context.Asociados.ToListAsync();
        

        // Obtener un asociado por ID
        public async Task<Asociado> GetAsociadoByIdAsync(int id) => await _context.Asociados.FirstOrDefaultAsync(a => a.AsociadoId == id);

        // Crear un nuevo asociado
        public async Task<Asociado> CreateAsociadoAsync(Asociado asociado)
        {
            _context.Asociados.Add(asociado);
            await _context.SaveChangesAsync();
            return asociado;
        }

        // Actualizar un asociado existente
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

        // Eliminar un asociado
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
