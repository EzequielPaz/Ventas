using EstructuraVentas.Dominio.Commons.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructuraVentas.LogicaNegocio.DTOs.Clientes
{
    public class ReadClienteDTO
    {
        public string IDClientes { get; set; } = string.Empty;
        public string? NombreCliente { get; set; }
        public string? Email { get; set; }
        public string? Documento { get; set; }
        public string? Celular { get; set; }
        public DateTime FechaDeRegistro { get; set; }
        public Estado Estado { get; set; }
    }
}
