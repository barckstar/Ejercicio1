using Ejercicio1.Models;

namespace Ejercicio1.Interfaces
{
    public interface ISalarioService
    {
        Task<IEnumerable<Asociado>> AumentarSalarioTodosAsync(decimal porcentajeAumento);
        Task<IEnumerable<Asociado>> AumentarSalarioDepartamentoAsync(int departamentoId, decimal porcentajeAumento);
        Task<Asociado?> AumentarSalarioAsociadoAsync(int asociadoId, decimal porcentajeAumento);
        Task<IEnumerable<Asociado>> DecrementarSalarioTodosAsync(decimal porcentajeDecremento);
        Task<IEnumerable<Asociado>> DecrementarSalarioDepartamentoAsync(int departamentoId, decimal porcentajeDecremento);
        Task<Asociado?> DecrementarSalarioAsociadoAsync(int asociadoId, decimal porcentajeDecremento);
    }
}
