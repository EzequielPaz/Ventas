using EstructuraVentas.Infraestructura.Commons.Bases.Request;
using EstructuraVentas.Infraestructura.Commons.Bases.Response;
using System.Linq.Expressions;

namespace EstructuraVentas.Infraestructura.Persistencia.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        void Update(T entity);
        void Remove(T entity);

        // Método genérico con filtros y paginación
        Task<BaseEntityResponse<T>> ListAsync(BaseFilterRequest filters,
                                              Expression<Func<T, bool>>? extraFilter = null);
    }
}
