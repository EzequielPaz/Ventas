using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructuraVentas.LogicaNegocio.DTOs.Clientes
{
    public class UpdateClienteDTO
    {
        public string IDClientes { get; set; } = string.Empty;

        public string NombreCliente { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Documento { get; set; } = string.Empty;
        public string Celular { get; set; } = string.Empty;

    }
}
