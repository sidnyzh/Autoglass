using System;
using Autoestrada.Domain.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Autoestrada.Domain.Entity.Entities
{
    public partial class AutoestradaContext : DbContext
    {
        public AutoestradaContext()
        {
        }

        public AutoestradaContext(DbContextOptions<AutoestradaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<Proveedor> Proveedores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.ToTable("productos");

                entity.HasIndex(e => e.Proveedor, "fk_Productos_proveedores_idx");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(9);

                entity.Property(e => e.FechaFabricacion).HasColumnType("date");

                entity.Property(e => e.FechaVencimiento).HasColumnType("date");

                entity.Property(e => e.Proveedor).HasColumnName("proveedor");

                entity.HasOne(d => d.ProveedorNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.Proveedor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Productos_proveedores");
            });

            modelBuilder.Entity<Proveedor>(entity =>
            {
                entity.HasKey(e => e.Codigo)
                    .HasName("PRIMARY");

                entity.ToTable("proveedores");

                entity.Property(e => e.Codigo).ValueGeneratedNever();

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(15);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
