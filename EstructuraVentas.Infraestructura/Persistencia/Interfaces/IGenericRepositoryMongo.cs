using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EstructuraVentas.Infraestructura.Persistencia.Interfaces
{
    public interface IGenericRepositoryMongo<T> where T : class

    {
        Task AddAsync(T entidad);
        Task<T?> GetByIdAsync(int id);
        Task<List<T>> GetAsync(Expression<Func<T, bool>>? filtro = null);
        Task UpdateAsync(T entidad, int id);
        Task DeleteAsync(int id);


        Task<(List<T> data, long total)> ListPagedAsync(int pageIndex, int records, Expression<Func<T, bool>>? filtro = null);
    }
}
