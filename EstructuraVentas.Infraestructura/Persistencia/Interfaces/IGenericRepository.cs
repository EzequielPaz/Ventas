using EstructuraVentas.Infraestructura.Commons.Bases.Request;
using EstructuraVentas.Infraestructura.Commons.Bases.Response;
using System.Linq.Expressions;

namespace EstructuraVentas.Infraestructura.Persistencia.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        // Obtener por Id con includes opcionales
        Task<T> GetByIdAsync(int id,Func<IQueryable<T>, IQueryable<T>>? include = null);

        // Obtener todos los registros
        Task<IEnumerable<T>> GetAllAsync();
        // Agregar nuevo registro
        Task AddAsync(T entity);
        // Actualizar registro existente
        void Update(T entity);
        // Eliminar registro
        void Remove(T entity);

        // Método genérico con filtros y paginación
        Task<BaseEntityResponse<T>> ListAsync(
    BaseFilterRequest filters,
    Expression<Func<T, bool>>? extraFilter = null,
    Func<IQueryable<T>, IQueryable<T>>? include = null
);

    }
}
