using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstructuraVentas.Dominio.Modelos;
using EstructuraVentas.Infraestructura.Contexto;

namespace EstructuraVentas.Infraestructura.Contexto
{
    public interface IUsuarioRepository
    {
        Task AgregarUsuarioAsync(Usuario usuario);
        Task<Usuario> ObtenerUsuarioPorIdAsync(int id);
        Task<Usuario> ObtenerPorNombreUsuarioAsync(string nombreUsuario);
        Task ActualizarUsuarioAsync(Usuario usuario);
        Task GuardarCambiosAsync();
    }
}