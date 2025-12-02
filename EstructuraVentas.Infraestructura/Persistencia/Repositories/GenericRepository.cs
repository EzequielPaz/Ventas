using EstructuraVentas.Infraestructura.Commons.Bases.Request;
using EstructuraVentas.Infraestructura.Commons.Bases.Response;
using EstructuraVentas.Infraestructura.Persistencia.Interfaces;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace EstructuraVentas.Infraestructura.Persistencia.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly IMongoCollection<T> _collection;

        public GenericRepository(IMongoDatabase database, string collectionName)
        {
            _collection = database.GetCollection<T>(collectionName);
        }

        public async Task<T?> GetByIdAsync(string id)
        {
            var filter = Builders<T>.Filter.Eq("_id", ObjectId.Parse(id));
            return await _collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _collection.Find(Builders<T>.Filter.Empty).ToListAsync();
        }

        public async Task AddAsync(T entity)
        {
            await _collection.InsertOneAsync(entity);
        }

        public async Task UpdateAsync(string id, T entity)
        {
            var filter = Builders<T>.Filter.Eq("_id", ObjectId.Parse(id));
            await _collection.ReplaceOneAsync(filter, entity);
        }

        public async Task RemoveAsync(string id)
        {
            var filter = Builders<T>.Filter.Eq("_id", ObjectId.Parse(id));
            await _collection.DeleteOneAsync(filter);
        }

        public async Task<BaseEntityResponse<T>> ListAsync(
            BaseFilterRequest filters,
            Expression<Func<T, bool>>? extraFilter = null)
        {
            if (filters.PageIndex <= 0) filters.PageIndex = 1;
            if (filters.PageSize <= 0) filters.PageSize = 10;
            if (filters.PageSize > 50) filters.PageSize = 50;

            var filter = extraFilter ?? (_ => true);

            var query = _collection.AsQueryable().Where(filter);

            var totalRecords = query.Count();

            var items = query
                .Skip((filters.PageIndex - 1) * filters.PageSize)
                .Take(filters.PageSize)
                .ToList();

            return new BaseEntityResponse<T>
            {
                TotalRecords = totalRecords,
                Records = items
            };
        }
    }
}
