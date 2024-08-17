using Ejercicio1.Models;  
using Microsoft.EntityFrameworkCore;

namespace TestEjercicio_1
{
    public class DatabaseTests
    {
        private DbContextOptions<EjercicioDbContext> _options;

        public DatabaseTests()
        {
            _options = new DbContextOptionsBuilder<EjercicioDbContext>()
                .UseSqlServer("Server=DESKTOP-8J7LS49;Database=EmpresaDB;Trusted_Connection=True;TrustServerCertificate=True;")
                .Options;
        }

        [Fact]
        public void PuedeConectarDatabaseTablaDepartamentos()
        {
            using (var context = new EjercicioDbContext(_options))
            {
                var departments = context.Departamentos.ToList();
                Assert.NotNull(departments);
                Assert.True(departments.Count > 0, "No se encontraron departamentos en la base de datos.");
            }
        }

        [Fact]
        public void PuedeConectarDatabaseTablaAsociado()
        {
            using (var context = new EjercicioDbContext(_options))
            {
                var asociado = context.Asociados.ToList();
                Assert.NotNull(asociado);
                Assert.True(asociado.Count > 0, "No se encontraron Asociado en la base de datos.");
            }
        }
    }
}
