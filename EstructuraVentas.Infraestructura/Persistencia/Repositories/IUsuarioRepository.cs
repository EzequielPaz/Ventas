using EstructuraVentas.Dominio.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructuraVentas.Infraestructura.Persistencia.Repositories
{
    public interface IUsuarioRepository
    {        
            Task AgregarUsuarioAsync(Usuario usuario);
            Task ActualizarUsuarioAsync(Usuario usuario);
            Task<Usuario> ObtenerUsuarioPorIdAsync(int id);
            Task<Usuario> ObtenerPorNombreUsuarioAsync(string nombreUsuario);
            Task GuardarCambiosAsync();

    }
}
