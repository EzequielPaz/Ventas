using EstructuraVentas.Dominio;
using EstructuraVentas.Dominio.Commons.Enums;
using EstructuraVentas.Infraestructura.Commons.Bases.Request;
using EstructuraVentas.Infraestructura.Commons.Bases.Response;
using EstructuraVentas.Infraestructura.Persistencia.Contexto;
using EstructuraVentas.Infraestructura.Persistencia.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EstructuraVentas.Infraestructura.Persistencia.Repositories
{
    public class ProductoRepository : GenericRepository<Producto>, IProductRepository
    {
        public ProductoRepository(ApplicationDbContext context) : base(context)
        {
        }

        // Listado con filtros y paginación
        public async Task<BaseEntityResponse<Producto>> ListProductos(BaseFilterRequest filters)
        {
            string texto = filters.TextFilter?.Trim();
            Estado? estado = filters.StateFilter.HasValue
                             ? (Estado?)filters.StateFilter.Value
                             : null;

            Expression<Func<Producto, bool>> filtro = p =>
                (string.IsNullOrEmpty(texto) ||
                    EF.Functions.Like(p.Nombre, $"%{texto}%") ||
                    (p.Descripcion != null && EF.Functions.Like(p.Descripcion, $"%{texto}%")) ||
                    (p.Marca != null && EF.Functions.Like(p.Marca, $"%{texto}%")) ||
                    (p.Codigo != null && EF.Functions.Like(p.Codigo, $"%{texto}%"))
                ) &&
                (!estado.HasValue || p.Estado == estado.Value);

            return await ListAsync(filters, filtro);
        }

        // Obtener cliente por ID
        public async Task<Producto?> GetProductById(int id)
        {
            return await GetByIdAsync(id);
        }

        // Registrar producto (sin SaveChanges, lo hace UnitOfWork)
        public async Task RegisterProduct(Producto producto)
        {
            await AddAsync(producto);
        }

        // Editar Producto (sin SaveChanges, lo hace UnitOfWork)
        public void EditProduct(Producto product)
        {
            Update(product);
        }

        // Eliminar producto (sin SaveChanges, lo hace UnitOfWork)
        public void DeleteProduct(Producto product)
        {
            Remove(product);
        }

    }
}
