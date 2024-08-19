using Ejercicio1.Models;

namespace Ejercicio1.Interfaces
{
    public interface IAuthService
    {
        string GenerateToken(UserLogin model);
        bool ValidateUser(UserLogin model);
    }
}
