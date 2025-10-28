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

        public async Task<T?> GetByIdAsync(int id) => await _dbSet.FindAsync(id);

        public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.AsNoTracking().ToListAsync();

        public async Task AddAsync(T entity) => await _dbSet.AddAsync(entity);

        public void Update(T entity) => _dbSet.Update(entity);

        public void Remove(T entity) => _dbSet.Remove(entity);

        public async Task<BaseEntityResponse<T>> ListAsync(BaseFilterRequest filters,
     Expression<Func<T, bool>>? extraFilter = null)
        {
            filters ??= new BaseFilterRequest();

            if (filters.PageIndex <= 0) filters.PageIndex = 1;
            if (filters.PageSize <= 0) filters.PageSize = 10;
            if (filters.PageSize > 50) filters.PageSize = 50;

            var query = _dbSet.AsNoTracking().AsQueryable();

            // Aplicar filtro extra si existe
            if (extraFilter != null)
                query = query.Where(extraFilter);

            // 1. Contar total de registros (usando la query base)
            var totalRecords = await query.CountAsync(); // <-- Esperamos el fin de esta ejecución

            // 2. Aplicar paginación y obtener ítems (usando la query base)
            var items = await query
            .Skip((filters.PageIndex - 1) * filters.PageSize)
            .Take(filters.PageSize)
            .ToListAsync(); // <-- Esta ejecución inicia DESPUÉS de la anterior

            return new BaseEntityResponse<T>
            {
                TotalRecords = totalRecords,
                Records = items
            };
        }


    }
}
