using EstructuraVentas.Dominio.Modelos;
using System.Threading.Tasks;

namespace EstructuraVentas.LogicaNegocio.Interfaces
{
    public interface IUsuarioServicio
    {
        Task<bool> AutenticarUsuarioAsync(string nombreUsuario, string contraseña);
        Task RegistrarUsuarioAsync(Usuario usuario);
        Task AsignarRolAUsuarioAsync(int usuarioId, RolDelUsuario rol);
    }
}