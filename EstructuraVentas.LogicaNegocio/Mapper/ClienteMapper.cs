using EstructuraVentas.Dominio;
using EstructuraVentas.Dominio.Modelos;
using EstructuraVentas.LogicaNegocio.DTOs.Clientes;
using EstructuraVentas.LogicaNegocio.DTOs.Proveedor;

namespace EstructuraVentas.LogicaNegocio.Mapper
{
    public static class ClienteMapper
    {
        // Crear entidad desde DTO de creación
        public static Cliente ToEntity(this CreateClienteDTO dto)
        {
            return new Cliente
            {
                NombreCliente = dto.NombreCliente,
                Email = dto.Email,
                Documento = dto.Documento,
                Celular = dto.Celular
                // IDClientes no se asigna aquí → lo genera Mongo automáticamente
            };
        }

        // Convertir entidad a DTO de lectura
        public static ReadClienteDTO ToReadDTO(this Cliente cliente)
        {
            return new ReadClienteDTO
            {
                IDClientes = cliente.IDClientes,  // ahora string → OK
                NombreCliente = cliente.NombreCliente,
                Email = cliente.Email,
                Documento = cliente.Documento,
                Celular = cliente.Celular
            };

        }

        // Actualizar entidad desde DTO de actualización
        public static void UpdateEntity(this Cliente cliente, UpdateClienteDTO dto)
        {
            cliente.NombreCliente = dto.NombreCliente;
            cliente.Email = dto.Email;
            cliente.Documento = dto.Documento;
            cliente.Celular = dto.Celular;
        }


    }
}
