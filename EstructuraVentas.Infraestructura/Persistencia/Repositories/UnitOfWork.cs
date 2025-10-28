using EstructuraVentas.Dominio;
using EstructuraVentas.Infraestructura.Persistencia.Contexto;
using EstructuraVentas.Infraestructura.Persistencia.Interfaces;

namespace EstructuraVentas.Infraestructura.Persistencia.Repositories
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IGenericRepository<Cliente> Clientes { get;  }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Clientes = new GenericRepository<Cliente>(_context);

        }

        public int SaveChanges() => _context.SaveChanges();
        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync(); 
        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
