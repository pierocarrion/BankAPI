using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Test_Backend.Models;

namespace Test_Backend.Contexts
{
    public partial class DataBaseApiTestContext : DbContext
    {
        public DataBaseApiTestContext()
        {
        }

        public DataBaseApiTestContext(DbContextOptions<DataBaseApiTestContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<Cuenta> Cuenta { get; set; } = null!;
        public virtual DbSet<Movimiento> Movimientos { get; set; } = null!;
        public virtual DbSet<Persona> Personas { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=DataBaseApiTest;Trusted_Connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("Cliente");

                entity.Property(e => e.Contrasena)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Persona)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.PersonaId)
                    .HasConstraintName("FK_Cliente_Persona");
            });

            modelBuilder.Entity<Cuenta>(entity =>
            {
                entity.HasKey(e => e.CuentaId)
                    .HasName("PK__Cuenta__40072E81BF65EB34");

                entity.Property(e => e.Estado)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroCuenta)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.SaldoInicial).HasColumnType("decimal(20, 3)");

                entity.Property(e => e.TipoCuenta)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.Cuentas)
                    .HasForeignKey(d => d.ClienteId)
                    .HasConstraintName("FK_Cuenta_Cliente");
            });

            modelBuilder.Entity<Movimiento>(entity =>
            {
                entity.ToTable("Movimiento");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.Saldo).HasColumnType("decimal(20, 3)");

                entity.Property(e => e.TipoMovimiento)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Valor).HasColumnType("decimal(20, 3)");

                entity.HasOne(d => d.Cuenta)
                    .WithMany(p => p.Movimientos)
                    .HasForeignKey(d => d.CuentaId)
                    .HasConstraintName("FK_Movimiento_Cuenta");
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.ToTable("Persona");

                entity.Property(e => e.Direccion).HasMaxLength(200);

                entity.Property(e => e.Genero)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Identificacion)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre).HasMaxLength(30);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
