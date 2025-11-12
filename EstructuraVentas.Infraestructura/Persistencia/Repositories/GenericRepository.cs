using EstructuraVentas.Infraestructura.Commons.Bases.Request;
using EstructuraVentas.Infraestructura.Commons.Bases.Response;
using EstructuraVentas.Infraestructura.Persistencia.Contexto;
using EstructuraVentas.Infraestructura.Persistencia.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EstructuraVentas.Infraestructura.Persistencia.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<T?> GetByIdAsync(int id, Func<IQueryable<T>, IQueryable<T>>? include = null)
        {
            IQueryable<T> query = _dbSet.AsQueryable();

            if (include != null)
                query = include(query);

            var entity = await _dbSet.FindAsync(id);

            if (entity == null)
                return null;

            // Si se pidió include, EF no lo carga con FindAsync
            if (include != null)
            {
                var keyProperty = _context.Model.FindEntityType(typeof(T))?.FindPrimaryKey()?.Properties.First();
                var keyName = keyProperty?.Name ?? "Id";
                var keyValue = typeof(T).GetProperty(keyName)?.GetValue(entity);

                return await query.FirstOrDefaultAsync(e => EF.Property<object>(e, keyName).Equals(keyValue));
            }

            return entity;
        }

        public async Task<IEnumerable<T>> GetAllAsync() =>
            await _dbSet.AsNoTracking().ToListAsync();

        public async Task AddAsync(T entity) =>
            await _dbSet.AddAsync(entity);

        public void Update(T entity) =>
            _dbSet.Update(entity);

        public void Remove(T entity) =>
            _dbSet.Remove(entity);

        public async Task<BaseEntityResponse<T>> ListAsync(
            BaseFilterRequest filters,
            Expression<Func<T, bool>>? extraFilter = null,
            Func<IQueryable<T>, IQueryable<T>>? include = null)
        {
            filters ??= new BaseFilterRequest();

            if (filters.PageIndex <= 0) filters.PageIndex = 1;
            if (filters.PageSize <= 0) filters.PageSize = 10;
            if (filters.PageSize > 50) filters.PageSize = 50;

            IQueryable<T> query = _dbSet.AsNoTracking();

            if (include != null)
                query = include(query);

            if (extraFilter != null)
                query = query.Where(extraFilter);

            // 🔹 Orden por defecto (importante para paginación estable)
            query = query.OrderBy(e => EF.Property<object>(e, "Id" + typeof(T).Name));

            var totalRecords = await query.CountAsync();
            var items = await query
                .Skip((filters.PageIndex - 1) * filters.PageSize)
                .Take(filters.PageSize)
                .ToListAsync();

            return new BaseEntityResponse<T>
            {
                TotalRecords = totalRecords,
                Records = items
            };
        }


    }
}
