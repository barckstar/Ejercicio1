using Ejercicio1.Models;

namespace Ejercicio1.Interfaces
{
    public interface IDepartamentoService
    {
        Task<IEnumerable<Departamento>> GetAllDepartamentosAsync();
        Task<Departamento> GetDepartamentoByIdAsync(int id);
        Task<Departamento> CreateDepartamentoAsync(Departamento departamento);
        Task<Departamento?> UpdateDepartamentoAsync(Departamento departamento);
        Task<bool> DeleteDepartamentoAsync(int id);
    }
}
