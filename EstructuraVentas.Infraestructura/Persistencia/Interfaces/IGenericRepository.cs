using EstructuraVentas.Infraestructura.Commons.Bases.Request;
using EstructuraVentas.Infraestructura.Commons.Bases.Response;
using System.Linq.Expressions;

namespace EstructuraVentas.Infraestructura.Persistencia.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(string id);

        Task<IEnumerable<T>> GetAllAsync();

        Task AddAsync(T entity);

        Task UpdateAsync(string id, T entity);

        Task RemoveAsync(string id);

        Task<BaseEntityResponse<T>> ListAsync(
            BaseFilterRequest filters,
            Expression<Func<T, bool>>? extraFilter = null
        );
    }
}
