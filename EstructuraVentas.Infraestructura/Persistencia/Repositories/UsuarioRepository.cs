using EstructuraVentas.Dominio.Modelos;
using EstructuraVentas.Infraestructura.Persistencia.Contexto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using EstructuraVentas.Infraestructura.Contexto;
using EstructuraVentas.Infraestructura.Persistencia.Contexto;



namespace EstructuraVentas.Infraestructura.Persistencia.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        //private readonly ApplicationDbContext _context; Reemplazamos para que funcione con MongoDB
        private readonly MongoDbContext _context;

        //public UsuarioRepository(ApplicationDbContext context)
        //{
        //    _context = context;
        //}

        //public async Task AgregarUsuarioAsync(Usuario usuario)
        //{
        //    await _context.Usuarios.AddAsync(usuario);
        //    await _context.SaveChangesAsync();
        //}
        //public async Task ActualizarUsuarioAsync(Usuario usuario)
        //{
        //     _context.Usuarios.Update(usuario);
        //}
        //public async Task<Usuario> ObtenerUsuarioPorIdAsync(int id)
        //{
        //    return await _context.Usuarios
        //        .FirstOrDefaultAsync(u => u.IDUsuarios == id);
        //}
        //public async Task<Usuario> ObtenerPorNombreUsuarioAsync(string nombreUsuario)
        //{
        //    return await _context.Usuarios.FirstOrDefaultAsync(u => u.NombreUsuario == nombreUsuario);

        //}
        //public async Task GuardarCambiosAsync()
        //{
        //    await _context.SaveChangesAsync();

        //}

        //-------------------------------------------------------------------------   Se comenta la parte de SQL para utilizar mongo -------------------------------

        public UsuarioRepository(MongoDbContext context)
        {
            _context = context;
        }

        public async Task AgregarUsuarioAsync(Usuario usuario)
        {
            await _context.Usuarios.InsertOneAsync(usuario);
        }

        public async Task<Usuario> ObtenerUsuarioPorIdAsync(int id)
        {
            return await _context.Usuarios.Find(u => u.IDUsuarios == id).FirstOrDefaultAsync();
        }

        public async Task<Usuario> ObtenerPorNombreUsuarioAsync(string nombreUsuario)
        {
            return await _context.Usuarios.Find(u => u.NombreUsuario == nombreUsuario).FirstOrDefaultAsync();
        }

        public async Task ActualizarUsuarioAsync(Usuario usuario)
        {
            var filtro = Builders<Usuario>.Filter.Eq(u => u.IDUsuarios, usuario.IDUsuarios);
            await _context.Usuarios.ReplaceOneAsync(filtro, usuario);
        }

        public async Task GuardarCambiosAsync()
        {
            await Task.CompletedTask; // Mongo no necesita SaveChanges
        }


    }
}
