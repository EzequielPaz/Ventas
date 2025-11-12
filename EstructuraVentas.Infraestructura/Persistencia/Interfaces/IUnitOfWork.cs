using EstructuraVentas.Dominio;
using EstructuraVentas.Dominio.Modelos;

namespace EstructuraVentas.Infraestructura.Persistencia.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        IGenericRepository<Cliente> Clientes { get; }
        IGenericRepository<Producto> Productos { get; } 
        IGenericRepository<Categoria> Categorias { get; }
        int SaveChanges();
        Task<int> SaveChangesAsync();

    }
}
