using EstructuraVentas.Dominio.Modelos;
using EstructuraVentas.Infraestructura.Persistencia.Repositories;
using EstructuraVentas.LogicaNegocio.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructuraVentas.LogicaNegocio.Servicios
{
    public class UsuarioServicio
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioServicio(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository ?? throw new ArgumentNullException(nameof(_usuarioRepository));

        }

        public async Task<bool> AutenticarUsuarioAsync(string nombreUsuario, string contraseña)
        {
            if (string.IsNullOrEmpty(nombreUsuario) || string.IsNullOrEmpty(contraseña))
                return false;

            var usuario = await _usuarioRepository.ObtenerPorNombreUsuarioAsync(nombreUsuario);

            if (usuario == null)
                return false;

            try
            {
                return BCrypt.Net.BCrypt.Verify(contraseña, usuario.ContraseñaHasheada);
            }
            catch
            {
                return false;
            }
        }

        public async Task RegistrarUsuarioAsync(Usuario usuario)
        {
            if (usuario == null)
                throw new ArgumentNullException(nameof(usuario));

            // Verificar si el nombre de usuario ya existe
            var usuarioExistente = await _usuarioRepository.ObtenerPorNombreUsuarioAsync(usuario.NombreUsuario);
            if (usuarioExistente != null)
                throw new InvalidOperationException("El nombre de usuario ya está en uso.");

            // Validar la contraseña
            var resultadoValidacion = await ValidarContraseñaAsync(usuario.Contraseña);
            if (!resultadoValidacion.EsValida)
            {
                var errores = string.Join(" ", resultadoValidacion.Errores);
                throw new ArgumentException("Error en la contraseña: " + errores);
            }

            // Hashear la contraseña antes de guardarla
            if (string.IsNullOrEmpty(usuario.ContraseñaHasheada))
            {
                usuario.ContraseñaHasheada = BCrypt.Net.BCrypt.HashPassword(usuario.Contraseña);
                //usuario.Contraseña = null; // Limpiar la contraseña en texto plano
            }

            try
            {
                await _usuarioRepository.AgregarUsuarioAsync(usuario);
                await _usuarioRepository.GuardarCambiosAsync();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("unique constraint") || ex.Message.Contains("duplicate"))
                    throw new InvalidOperationException("El nombre de usuario ya está en uso.", ex);
                throw;
            }
        }

        public async Task AsignarRolAUsuarioAsync(int usuarioId, RolDelUsuario rol)
        {
            var usuario = await _usuarioRepository.ObtenerUsuarioPorIdAsync(usuarioId);
            if (usuario == null)
                throw new InvalidOperationException("El usuario no existe.");

            usuario.RolDelUsuario = rol;

            try
            {
                await _usuarioRepository.ActualizarUsuarioAsync(usuario);
                await _usuarioRepository.GuardarCambiosAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error al asignar el rol al usuario.", ex);
            }
        }

        public static Task<ResultadoValidacion> ValidarContraseñaAsync(string contraseña)
        {
            var resultado = new ResultadoValidacion();



            if (string.IsNullOrWhiteSpace(contraseña))
            {
                resultado.Errores.Add("La contraseña no puede estar vacía.");
            }
            else
            {
                if (contraseña.Length < 6)
                    resultado.Errores.Add("La contraseña debe tener al menos 6 caracteres.");

                if (!contraseña.Any(char.IsUpper))
                    resultado.Errores.Add("La contraseña debe contener al menos una letra mayúscula.");

                if (!contraseña.Any(char.IsDigit))
                    resultado.Errores.Add("La contraseña debe contener al menos un número.");
            }

            resultado.EsValida = resultado.Errores.Count == 0;

            return Task.FromResult(resultado);
        }
    }
}
