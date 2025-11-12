using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstructuraVentas.Dominio.Modelos;
using EstructuraVentas.Dominio;

namespace EstructuraVentas.Infraestructura.Persistencia.Contexto
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Compra> Compras { get; set; }

        public DbSet<Venta> Ventas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cliente>()
                .HasKey(c => c.IDClientes);

            modelBuilder.Entity<Usuario>(entity =>
            {
                // Guardar enums como texto
                entity.Property(u => u.RolDelUsuario)
                      .HasConversion<string>();

                entity.Property(u => u.Estado)
                      .HasConversion<string>();

                // Agregar índice único para NombreUsuario
                //entity.HasIndex(u => u.NombreUsuario)
                //      .IsUnique();
            });

            modelBuilder.Entity<Producto>()
                .HasKey(c => c.IdProducto);

            modelBuilder.Entity<Producto>()
                .Property(p => p.Precio)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Producto>()
                .HasOne(p => p.Categoria)
                .WithMany(c => c.Productos)
                .HasForeignKey(p => p.CategoriaId);

            // *** CONFIGURACIÓN DE LA RELACIÓN COMPRA - PROVEEDOR ***
            modelBuilder.Entity<Compra>()
                .HasOne(c => c.Proveedor)
                .WithMany(p => p.Compras)
                .HasForeignKey(c => c.ProveedorId)       // FK en Compra
                .HasPrincipalKey(p => p.IdProveedor);    // PK en Proveedor

            modelBuilder.Entity<Venta>()
                .HasKey(c => c.IdVentas);

            modelBuilder.Entity<Venta>()
       .Property(v => v.Precio)
       .HasPrecision(10, 2);
        }
    }


}