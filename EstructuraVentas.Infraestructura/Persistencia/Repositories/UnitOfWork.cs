using EstructuraVentas.Dominio;
using EstructuraVentas.Dominio.Modelos;
using EstructuraVentas.Infraestructura.Contexto;
using EstructuraVentas.Infraestructura.Persistencia.Contexto;
using EstructuraVentas.Infraestructura.Persistencia.Interfaces;
using MongoDB.Driver;

namespace EstructuraVentas.Infraestructura.Persistencia.Repositories
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly IMongoDatabase _database;

        public IMongoDatabase Database => _database;


        public IGenericRepository<Cliente> Clientes { get; }
        public IGenericRepository<Producto> Productos { get; }
        public IGenericRepository<Categoria> Categorias { get; }
        public IGenericRepository<Proveedor> Proveedores { get; }

        // 👍 Repositorio personalizado
        public IUsuarioRepository Usuarios { get; }
        public IGenericRepository<Proveedor> Proveedores { get; }

        public UnitOfWork(IMongoDatabase database)
        {
            _database = database;

            Clientes = new GenericRepository<Cliente>(_database, "Clientes");
            Productos = new GenericRepository<Producto>(_database, "Productos");
            Categorias = new GenericRepository<Categoria>(_database, "Categorias");
            // 👍 Tu repositorio personalizado
            Usuarios = new UsuarioRepository(_database);
            Proveedores = new GenericRepository<Proveedor>(_database, "Proveedores");
        }

        public int SaveChanges() => 1;

        public Task<int> SaveChangesAsync() => Task.FromResult(1);

        public void Dispose()
        {
            // No hay nada que liberar en Mongo
        }
    }
}
