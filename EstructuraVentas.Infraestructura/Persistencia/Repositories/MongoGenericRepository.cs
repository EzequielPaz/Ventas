using EstructuraVentas.Infraestructura.Commons.Bases.Request;
using EstructuraVentas.Infraestructura.Commons.Bases.Response;
using EstructuraVentas.Infraestructura.Persistencia.Contexto;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EstructuraVentas.Infraestructura.Persistencia.Interfaces
{
    public class MongoGenericRepository<T> : IGenericRepositoryMongo<T> where T : class
    {
        protected readonly IMongoCollection<T> _collection;

        // Constructor recibe MongoContext
        public MongoGenericRepository(MongoContext context, string collectionName)
        {
            _collection = context.GetCollection<T>(collectionName);
        }

        public async Task AddAsync(T entidad)
        {
            await _collection.InsertOneAsync(entidad);
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            // Intentamos buscar por los campos comunes de Id que tengas
            var filter = Builders<T>.Filter.Eq("IdProveedor", id) |
                         Builders<T>.Filter.Eq("IDClientes", id) |
                         Builders<T>.Filter.Eq("IdProducto", id);

            return await _collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<List<T>> GetAsync(Expression<Func<T, bool>>? filtro = null)
        {
            return filtro == null
                ? await _collection.Find(_ => true).ToListAsync()
                : await _collection.Find(filtro).ToListAsync();
        }

        public async Task UpdateAsync(T entidad, int id)
        {
            var filter = Builders<T>.Filter.Eq("IdProveedor", id) |
                         Builders<T>.Filter.Eq("IDClientes", id) |
                         Builders<T>.Filter.Eq("IdProducto", id);

            await _collection.ReplaceOneAsync(filter, entidad);
        }

        public async Task DeleteAsync(int id)
        {
            var filter = Builders<T>.Filter.Eq("IdProveedor", id) |
                         Builders<T>.Filter.Eq("IDClientes", id) |
                         Builders<T>.Filter.Eq("IdProducto", id);

            await _collection.DeleteOneAsync(filter);
        }

        public async Task<(List<T> data, long total)> ListPagedAsync(int pageIndex, int records, Expression<Func<T, bool>>? filtro = null)
        {
            var find = filtro == null ? _collection.Find(_ => true) : _collection.Find(filtro);

            var total = await find.CountDocumentsAsync();

            var lista = await find
                .Skip((pageIndex - 1) * records)
                .Limit(records)
                .ToListAsync();

            return (lista, total);
        }

        public async Task<BaseEntityResponse<T>> ListAsync(BaseFilterRequest filters, Expression<Func<T, bool>>? filtro = null)
        {
            var find = filtro == null ? _collection.Find(_ => true) : _collection.Find(filtro);

            var total = await find.CountDocumentsAsync();

            var registros = await find
                .Skip((filters.PageIndex - 1) * filters.PageSize)
                .Limit(filters.PageSize)
                .ToListAsync();

            return new BaseEntityResponse<T>
            {
                TotalRecords = (int)total,
                Records = registros
            };
        }

    }
}
