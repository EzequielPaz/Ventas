using EstructuraVentas.Dominio;
using EstructuraVentas.LogicaNegocio.DTOs.Clientes;

namespace EstructuraVentas.LogicaNegocio.Mapper
{
    public static class ClienteMapper
    {
        public static Cliente ToEntity(this CreateClienteDTO dto)
        {
            return new Cliente
            {
                NombreCliente = dto.NombreCliente,
                Email = dto.Email,
                Documento = dto.Documento,
                Celular = dto.Celular
            };
        }

        public static ReadClienteDTO ToEntity(this Cliente cliente)
        {
            return new ReadClienteDTO
            {
                IDClientes = cliente.IDClientes,
                NombreCliente = cliente.NombreCliente,
                Email = cliente.Email,
                Documento = cliente.Documento,
                Celular = cliente.Celular
            };
        }

        public static void UpdateEntity(this Cliente cliente, UpdateClienteDTO dto)
        {
            cliente.NombreCliente = dto.NombreCliente;
            cliente.Email = dto.Email;
            cliente.Documento = dto.Documento;
            cliente.Celular = dto.Celular;
        }


    }
}
