using EstructuraVentas.Dominio.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructuraVentas.LogicaNegocio.DTOs.Proveedor
{
    public class UpdateProveedorDto
    {
        public int IdProveedor { get; set; }

        public string RazonSocial { get; set; }
        public string CUIT { get; set; }
        public string CodigoProveedor { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }

    }
}
