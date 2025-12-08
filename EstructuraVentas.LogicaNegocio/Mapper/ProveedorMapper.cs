using EstructuraVentas.Dominio.Modelos;
using EstructuraVentas.LogicaNegocio.DTOs.Proveedor;

namespace EstructuraVentas.LogicaNegocio.Mapper
{
    public static class ProveedorMapper
    {
        // Crear entidad desde DTO de creación
        public static Proveedor ToEntity(this CreateProveedorDTO dto)
        {
            return new Proveedor
            {
                RazonSocial = dto.RazonSocial,
                CodigoProveedor = dto.CodigoProveedor,
                CUIT = dto.CUIT,
                Telefono = dto.Telefono,
                Correo = dto.Correo,
                // IDClientes no se asigna aquí → lo genera Mongo automáticamente
            };
        }

        // Convertir entidad a DTO de lectura
        public static ReadProveedorDTO ToReadDTO(this Proveedor proveedor)
        {
            return new ReadProveedorDTO
            {
                IdProveedor = proveedor.IdProveedor,  // ahora string → OK
                RazonSocial = proveedor.RazonSocial,
                CodigoProveedor = proveedor.CodigoProveedor,
                CUIT = proveedor.CUIT,
                Telefono = proveedor.Telefono
            };

        }

        // Actualizar entidad desde DTO de actualización
        public static void UpdateEntity(this Proveedor proveedor, UpdateProveedorDTO dto)
        {
            proveedor.RazonSocial = dto.RazonSocial;
            proveedor.CodigoProveedor = dto.RazonSocial;
            proveedor.CUIT = dto.RazonSocial;
            proveedor.Telefono = dto.RazonSocial;
            proveedor.Correo = dto.Correo;
        }
    }
}
