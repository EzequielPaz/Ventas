using EstructuraVentas.Dominio;
using EstructuraVentas.Infraestructura.Commons.Bases.Request;
using EstructuraVentas.Infraestructura.Commons.Bases.Response;
using EstructuraVentas.Infraestructura.Persistencia.Contexto;
using EstructuraVentas.Infraestructura.Persistencia.Interfaces;
using System.Linq.Expressions;
using EstructuraVentas.Dominio.Commons.Enums;

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
            // Normalizamos filtros
            string texto = filters.TextFilter?.Trim().ToLower();
            Estado? estado = filters.StateFilter.HasValue
                ? (Estado?)filters.StateFilter.Value
                : null;

            // Construimos expresión de filtrado
            Expression<Func<Producto, bool>> filtro = p =>
                (string.IsNullOrEmpty(texto) ||
                    p.Nombre.ToLower().Contains(texto) ||
                    (p.Descripcion != null && p.Descripcion.ToLower().Contains(texto)) ||
                    (p.Marca != null && p.Marca.ToLower().Contains(texto)) ||
                    p.Codigo.ToLower().Contains(texto)) &&
                (!estado.HasValue || p.Estado == estado.Value);

            // Llamada al método genérico
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
        public void DeleteClient(Producto product)
        {
            Remove(product);
        }

    }
}
