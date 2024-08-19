using Ejercicio1.Models;

namespace Ejercicio1.Interfaces
{
    public interface IAsociadoService
    {
        Task<IEnumerable<Asociado>> GetAllAsociadosAsync();
        Task<Asociado> GetAsociadoByIdAsync(int id);
        Task<Asociado> CreateAsociadoAsync(Asociado asociado);
        Task<Asociado?> UpdateAsociadoAsync(Asociado asociado);
        Task<bool> DeleteAsociadoAsync(int id);
    }

}
