using Ejercicio1.Models;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace TestEjercicio_1
{
    public class DatabaseTests
    {
        private readonly DbContextOptions<EjercicioDbContext> _options;

        public DatabaseTests()
        {
            _options = new DbContextOptionsBuilder<EjercicioDbContext>()
                .UseSqlServer("Server=DESKTOP-8J7LS49;Database=EmpresaDB;Trusted_Connection=True;TrustServerCertificate=True;")
                .Options;
        }

        [Fact]
        public void Puede_Conectar_Database_TablaDepartamentos()
        {
            // Arrange
            var context = new EjercicioDbContext(_options);

            // Act
            var departments = context.Departamentos.ToList();

            // Assert
            Assert.NotNull(departments);
            Assert.True(departments.Count > 0, "No se encontraron departamentos en la base de datos.");

        }

        [Fact]
        public void Puede_Conectar_Database_TablaAsociado()
        {
            // Arrange
            var context = new EjercicioDbContext(_options);

            // Act
            var asociado = context.Asociados.ToList();

            // Assert
            Assert.NotNull(asociado);
            Assert.True(asociado.Count > 0, "No se encontraron asociados en la base de datos.");

        }
    }
}
