using EstructuraVentas.Dominio;
using EstructuraVentas.Dominio.Modelos;
using EstructuraVentas.Infraestructura.Contexto;

namespace EstructuraVentas.Infraestructura.Persistencia.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        IGenericRepository<Cliente> Clientes { get; }
        IGenericRepository<Producto> Productos { get; }
        IGenericRepository<Categoria> Categorias { get; }


        IUsuarioRepository Usuarios { get; }
        int SaveChanges();
        Task<int> SaveChangesAsync();

    }
}
