using EstructuraVentas.Dominio.Modelos;
using EstructuraVentas.Infraestructura.Persistencia.Interfaces;
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
        private readonly IUnitOfWork _unitOfWork;

        public UsuarioServicio(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> AutenticarUsuarioAsync(string nombreUsuario, string contraseña)
        {
            if (string.IsNullOrEmpty(nombreUsuario) || string.IsNullOrEmpty(contraseña))
                return false;

            // 🔥 Buscar por nombre de usuario, NO por ID
            var usuario = await _unitOfWork.Usuarios.ObtenerPorNombreUsuarioAsync(nombreUsuario);

            if (usuario == null)
                return false;

            return BCrypt.Net.BCrypt.Verify(contraseña, usuario.ContraseñaHasheada);
        }

        public async Task RegistrarUsuarioAsync(Usuario usuario)
        {
            if (usuario == null)
                throw new ArgumentNullException(nameof(usuario));

            // 🔥 Verificar si ya existe
            var usuarioExistente = await _unitOfWork.Usuarios.ObtenerPorNombreUsuarioAsync(usuario.NombreUsuario);

            if (usuarioExistente != null)
                throw new InvalidOperationException("El nombre de usuario ya está en uso.");

            // 🔥 Validar contraseña
            var resultadoValidacion = await ValidarContraseñaAsync(usuario.Contraseña);

            if (!resultadoValidacion.EsValida)
            {
                var errores = string.Join(" ", resultadoValidacion.Errores);
                throw new ArgumentException("Error en la contraseña: " + errores);
            }

            //Hashear antes de guardar
            usuario.ContraseñaHasheada = BCrypt.Net.BCrypt.HashPassword(usuario.Contraseña);
            usuario.Contraseña = null;

            await _unitOfWork.Usuarios.AddAsync(usuario);
        }

        public async Task AsignarRolAUsuarioAsync(string usuarioId, RolDelUsuario rol)
        {
            var usuario = await _unitOfWork.Usuarios.GetByIdAsync(usuarioId);

            if (usuario == null)
                throw new InvalidOperationException("El usuario no existe.");

            usuario.RolDelUsuario = rol;

            // 🔥 Actualiza por ID
            await _unitOfWork.Usuarios.UpdateAsync(usuarioId, usuario);
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
