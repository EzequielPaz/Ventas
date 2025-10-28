using EstructuraVentas.Dominio;

namespace EstructuraVentas.Infraestructura.Persistencia.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        IGenericRepository<Cliente> Clientes { get; }
        //Aca deben agregarse los demas repositorios

        int SaveChanges();
        Task<int> SaveChangesAsync();

    }
}
