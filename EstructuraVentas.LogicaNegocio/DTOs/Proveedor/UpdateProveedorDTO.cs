using EstructuraVentas.Dominio.Commons.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructuraVentas.LogicaNegocio.DTOs.Proveedor
{
    public class UpdateProveedorDTO
    {
        public string IdProveedor { get; set; } = string.Empty;

        public string? RazonSocial { get; set; }
        public string? CUIT { get; set; }
        public string? CodigoProveedor { get; set; }
        public string? Telefono { get; set; }
        public string? Correo { get; set; }
        public Estado? Estado { get; set; }

    }
}
