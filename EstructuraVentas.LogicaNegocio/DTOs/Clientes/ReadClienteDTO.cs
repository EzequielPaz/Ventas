using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructuraVentas.LogicaNegocio.DTOs.Clientes
{
    public class ReadClienteDTO
    {
        public int IDClientes { get; set; }
        public string NombreCliente { get; set; }
        public string Email { get; set; }
        public string Documento { get; set; }
        public string Celular { get; set; }
        public string FechaDeRegistro { get; set; } 
        public string Estado { get; set; }
    }
}
