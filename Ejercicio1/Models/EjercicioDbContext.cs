using Microsoft.EntityFrameworkCore;

namespace Ejercicio1.Models;

public partial class EjercicioDbContext : DbContext
{
    public EjercicioDbContext()
    {
    }

    public EjercicioDbContext(DbContextOptions<EjercicioDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Asociado> Asociados { get; set; }

    public virtual DbSet<Departamento> Departamentos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("EmpresaDBConnection"));
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Asociado>(entity =>
        {
            entity.HasKey(e => e.AsociadoId).HasName("PK__Asociado__C15DFE4C09C57AB8");

            entity.Property(e => e.AsociadoId).HasColumnName("AsociadoID");
            entity.Property(e => e.DepartamentoId).HasColumnName("DepartamentoID");
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Salario).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Departamento).WithMany(p => p.Asociados)
                .HasForeignKey(d => d.DepartamentoId)
                .HasConstraintName("FK__Asociados__Depar__398D8EEE");
        });

        modelBuilder.Entity<Departamento>(entity =>
        {
            entity.HasKey(e => e.DepartamentoId).HasName("PK__Departam__66BB0E1E5679401C");
            entity.Property(e => e.DepartamentoId).HasColumnName("DepartamentoID");
            entity.Property(e => e.Nombre).HasMaxLength(100);

            entity.HasMany(d => d.Asociados)
                  .WithOne(a => a.Departamento)
                  .HasForeignKey(a => a.DepartamentoId)
                  .HasConstraintName("FK__Asociados__Depar__398D8EEE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
