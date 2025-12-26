using EstructuraVentas.Dominio.Modelos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructuraVentas.LogicaNegocio.DTOs.Proveedor
{
    public class CreateProveedorDto 
    {
        public string RazonSocial { get; set; }
        public string CUIT { get; set; }
        public string CodigoProveedor { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }

    }
}
