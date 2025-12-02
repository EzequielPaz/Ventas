using EstructuraVentas.Dominio.Modelos;
using EstructuraVentas.Infraestructura.Contexto;
using EstructuraVentas.Infraestructura.Persistencia.Interfaces;
using MongoDB.Driver;

namespace EstructuraVentas.Infraestructura.Persistencia.Repositories
{
    public class UsuarioRepository : GenericRepository<Usuario>, IUsuarioRepository
    {
        private readonly IMongoCollection<Usuario> _usuarios;

        public UsuarioRepository(IMongoDatabase database)
            : base(database, "Usuarios")
        {
            _usuarios = database.GetCollection<Usuario>("Usuarios");
        }

        /// <summary>
        /// Método personalizado: buscar por nombre de usuario
        /// </summary>
        public async Task<Usuario?> ObtenerPorNombreUsuarioAsync(string nombreUsuario)
        {
            return await _usuarios
            .Find(u => u.NombreUsuario == nombreUsuario)
            .FirstOrDefaultAsync();

        }
    }
}
