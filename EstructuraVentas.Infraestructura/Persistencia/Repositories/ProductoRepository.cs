using EstructuraVentas.Dominio;
using EstructuraVentas.Dominio.Commons.Enums;

using EstructuraVentas.Infraestructura.Commons.Bases.Request;
using EstructuraVentas.Infraestructura.Commons.Bases.Response;
using EstructuraVentas.Infraestructura.Persistencia.Interfaces;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace EstructuraVentas.Infraestructura.Persistencia.Repositories
{
    public class ProductoRepository
        : GenericRepository<Producto>, IProductRepository
    {
        private readonly IMongoCollection<Producto> _collection;

        public ProductoRepository(IMongoDatabase database)
            : base(database, "Productos")
        {
            _collection = database.GetCollection<Producto>("Productos");
        }

        // ============================================
        // LISTADO CON FILTROS + PAGINACIÓN (MongoDB)
        // ============================================
        public async Task<BaseEntityResponse<Producto>> ListProductos(BaseFilterRequest filters)
        {
            var builder = Builders<Producto>.Filter;
            var filter = builder.Empty;

            // Texto a buscar
            if (!string.IsNullOrEmpty(filters.TextFilter))
            {
                var texto = filters.TextFilter.Trim();

                filter &= builder.Or(
                    builder.Regex(p => p.Nombre, new MongoDB.Bson.BsonRegularExpression(texto, "i")),
                    builder.Regex(p => p.Descripcion, new MongoDB.Bson.BsonRegularExpression(texto, "i")),
                    builder.Regex(p => p.Marca, new MongoDB.Bson.BsonRegularExpression(texto, "i")),
                    builder.Regex(p => p.Codigo, new MongoDB.Bson.BsonRegularExpression(texto, "i"))
                );
            }

            // Filtro por Estado
            if (filters.StateFilter.HasValue)
            {
                Estado estado = (Estado)filters.StateFilter.Value;
                filter &= builder.Eq(p => p.Estado, estado);
            }

            long totalRecords = await _collection.CountDocumentsAsync(filter);

            var result = await _collection.Find(filter)
                .Skip((filters.PageIndex - 1) * filters.PageSize)
                .Limit(filters.PageSize)
                .ToListAsync();

            return new BaseEntityResponse<Producto>
            {
                TotalRecords = (int)totalRecords,
                Records = result
            };
        }

        // ============================================
        // OBTENER PRODUCTO POR ID
        // ============================================
        public async Task<Producto?> GetProductById(string id)
        {
            return await _collection.Find(p => p.IdProducto == id).FirstOrDefaultAsync();
        }

        // ============================================
        // REGISTRAR PRODUCTO
        // ============================================
        public async Task RegisterProduct(Producto producto)
        {
            await _collection.InsertOneAsync(producto);
        }

        // ============================================
        // EDITAR PRODUCTO
        // ============================================
        public async Task EditProduct(Producto producto)
        {
            await _collection.ReplaceOneAsync(
                p => p.IdProducto == producto.IdProducto,
                producto);
        }

        // ============================================
        // ELIMINAR PRODUCTO
        // ============================================
        public async Task DeleteProduct(Producto producto)
        {
            await _collection.DeleteOneAsync(p => p.IdProducto == producto.IdProducto);
        }
    }
}
