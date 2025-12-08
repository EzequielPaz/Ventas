using EstructuraVentas.Dominio;
using EstructuraVentas.Dominio.Commons.Enums;
using EstructuraVentas.Dominio.Modelos;
using EstructuraVentas.Infraestructura.Commons.Bases.Request;
using EstructuraVentas.Infraestructura.Commons.Bases.Response;
using EstructuraVentas.Infraestructura.Persistencia.Contexto;
using EstructuraVentas.Infraestructura.Persistencia.Interfaces;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructuraVentas.Infraestructura.Persistencia.Repositories
{

    public class ProveedorRepository : GenericRepository<Proveedor>, IProveedorRepository
    {
        private readonly IMongoCollection<Proveedor> _collection;         
        public ProveedorRepository(IMongoDatabase database)
    : base(database, "Proveedor")
        {
            _collection = database.GetCollection<Proveedor>("Proveedores");
        }
        public async Task<BaseEntityResponse<Proveedor>> ListProveedor(BaseFilterRequest filters)
        {
            var builder = Builders<Proveedor>.Filter;
            var filter = builder.Empty;

            // Buscar por texto (CodigoProveedor)
            if (!string.IsNullOrEmpty(filters.TextFilter))
            {
                filter &= builder.Regex(c => c.CodigoProveedor,
                    new MongoDB.Bson.BsonRegularExpression(filters.TextFilter, "i"));
            }

            // Filtro por Estado
            if (filters.StateFilter.HasValue)
            {
                Estado estado = (Estado)filters.StateFilter.Value;
                filter &= builder.Eq(c => c.Estado, estado);
            }

            // Contar total
            long totalRecords = await _collection.CountDocumentsAsync(filter);

            // Orden + Paginación
            var result = await _collection.Find(filter)
                .Skip((filters.PageIndex - 1) * filters.PageSize)
                .Limit(filters.PageSize)
                .ToListAsync();

            return new BaseEntityResponse<Proveedor>
            {
                TotalRecords = (int)totalRecords,
                Records = result
            };
        }

        // ================================
        // OBTENER POR ID
        // ================================
        public async Task<Proveedor?> GetClientById(string id)
        {
            return await _collection.Find(c => c.IdProveedor == id).FirstOrDefaultAsync();
        }

        // ================================
        // REGISTRAR CLIENTE
        // ================================
        public async Task RegisterClient(Proveedor proveedor)
        {
            await _collection.InsertOneAsync(proveedor);
        }

        // ================================
        // EDITAR CLIENTE
        // ================================
        public async Task EditClient(Proveedor proveedor)
        {
            await _collection.ReplaceOneAsync(c => c.IdProveedor == proveedor.IdProveedor, proveedor);
        }

        // ================================
        // ELIMINAR CLIENTE
        // ================================
        public async Task DeleteClient(Proveedor proveedor)
        {
            await _collection.DeleteOneAsync(c => c.IdProveedor == proveedor.IdProveedor);
        }

    }
}
