using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EstructuraVentas.Dominio.Commons.Enums;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructuraVentas.Dominio.Modelos
{
    public class Usuario
    {
        [Key]
        public int IDUsuarios { get; set; }

        [Required(ErrorMessage = "El nombre de usuario es obligatorio.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre de usuario debe tener entre 3 y 50 caracteres.")]
        public string NombreUsuario { get; set; }

        [Required]
        [MinLength(6, ErrorMessage = "La contraseña debe tener al menos 6 caracteres.")]
        public string ContraseñaHasheada { get; set; } = string.Empty;

        [NotMapped]
        [Required]
        public string Contraseña { get; set; }

        public RolDelUsuario RolDelUsuario { get; set; }

        public DateTime FechaDeRegistro { get; set; } = DateTime.Now;

        public Estado Estado { get; set; } = Estado.Activo;

    }


    public enum RolDelUsuario
    {
        Admin,
        Gerente,
        Empleado
    }

    
}
