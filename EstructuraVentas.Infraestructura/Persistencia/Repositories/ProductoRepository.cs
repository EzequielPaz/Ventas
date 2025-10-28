using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstructuraVentas.Dominio;
using Microsoft.EntityFrameworkCore;
using EstructuraVentas.Dominio;
using EstructuraVentas.Infraestructura.Persistencia.Contexto;


namespace EstructuraVentas.Infraestructura.Persistencia.Repositories
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Agrega un nuevo producto
        public async Task AgregarProductoAsync(Producto producto)
        {
            if (producto == null)
                throw new ArgumentNullException(nameof(producto), "El producto no puede ser nulo.");

            try
            {
                _context.Productos.Add(producto);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error al agregar el producto a la base de datos.", ex);
            }
        }

        // Devuelve la lista de productos sin seguimiento (lectura)
        public async Task<List<Producto>> MostrarProductoAsync()
        {
            return await _context.Productos
                .AsNoTracking()
                .ToListAsync();
        }

        // Devuelve un producto por ID
        public async Task<Producto?> ObtenerPorIdProductoAsync(int IdProducto)
        {
            return await _context.Productos
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.IdProducto == IdProducto);
        }

        // Elimina un producto por ID
        public async Task EliminarProductoAsync(int IdProducto)
        {
            var producto = await _context.Productos.FindAsync(IdProducto);
            if (producto != null)
            {
                _context.Productos.Remove(producto);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException("No se encontró el producto a eliminar.");
            }
        }

        // Modifica un producto existente
        public async Task ModificarProductoAsync(Producto producto)
        {
            var existente = await _context.Productos.FindAsync(producto.IdProducto);
            if (existente != null)
            {
                _context.Entry(existente).CurrentValues.SetValues(producto);
            }
            else
            {
                // Esto no debería ocurrir normalmente, pero cubrimos el caso
                _context.Productos.Update(producto);
            }

            await _context.SaveChangesAsync();
        }
    }
}
