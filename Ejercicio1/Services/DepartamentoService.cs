using Ejercicio1.Interfaces;
using Ejercicio1.Models;
using Microsoft.EntityFrameworkCore;

namespace Ejercicio1.Services
{
    public class DepartamentoService : IDepartamentoService
    {
        private readonly EjercicioDbContext _context;

        public DepartamentoService(EjercicioDbContext context)
        {
            _context = context;
        }

        // Obtener todos los departamentos
        public async Task<IEnumerable<Departamento>> GetAllDepartamentosAsync() => await _context.Departamentos.ToListAsync();

        // Obtener un departamento por ID
        public async Task<Departamento> GetDepartamentoByIdAsync(int id) => await _context.Departamentos.FirstOrDefaultAsync(d => d.DepartamentoId == id);

        // Crear un nuevo departamento
        public async Task<Departamento> CreateDepartamentoAsync(Departamento departamento)
        {
            _context.Departamentos.Add(departamento);
            await _context.SaveChangesAsync();
            return departamento;
        }

        // Actualizar un departamento existente
        public async Task<Departamento?> UpdateDepartamentoAsync(Departamento departamento)
        {
            var existingDepartamento = await _context.Departamentos.FirstOrDefaultAsync(d => d.DepartamentoId == departamento.DepartamentoId);

            if (existingDepartamento == null)
            {
                return null;
            }

            existingDepartamento.Nombre = departamento.Nombre;

            _context.Departamentos.Update(existingDepartamento);
            await _context.SaveChangesAsync();
            return existingDepartamento;
        }

        // Eliminar un departamento
        public async Task<bool> DeleteDepartamentoAsync(int id)
        {
            var departamento = await _context.Departamentos.FirstOrDefaultAsync(d => d.DepartamentoId == id);

            if (departamento == null)
            {
                return false;
            }

            _context.Departamentos.Remove(departamento);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
