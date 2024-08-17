using System;
using System.Collections.Generic;
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
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-8J7LS49;Database=EmpresaDB;Trusted_Connection=True;TrustServerCertificate=True");

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
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
