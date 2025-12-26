using EstructuraVentas.Dominio;
using EstructuraVentas.Dominio.Modelos;
using EstructuraVentas.LogicaNegocio.DTOs.Clientes;
using EstructuraVentas.LogicaNegocio.DTOs.Proveedor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructuraVentas.LogicaNegocio.Mapper
{
    public static class ProveedorMapper
    {
        public static Proveedor ToEntity(this CreateProveedorDto dto, int nuevoId)
        {
            if (dto == null) return null;

            return new Proveedor
            {
                IdProveedor = nuevoId,
                RazonSocial = dto.RazonSocial,
                CodigoProveedor = dto.CodigoProveedor,
                CUIT = dto.CUIT,
                CodigoProveedor = dto.CodigoProveedor,
                Telefono = dto.Telefono,
                Correo = dto.Correo,
                FechaDeRegistro = DateTime.Now
            };
        }

        public static ReadProveedorDto ToEntity(this Proveedor proveedor)
        {
            return new ReadProveedorDto
            {
                IdProveedor = proveedor.IdProveedor,
                RazonSocial = proveedor.RazonSocial,
                CUIT = proveedor.CUIT,
                CodigoProveedor = proveedor.CodigoProveedor,
                Telefono = proveedor.Telefono,
                Correo = proveedor.Correo,
                FechaDeRegistro = proveedor.FechaDeRegistro.ToString("dd/MM/yyyy")

            };

        }

        public static void UpdateEntity(this Proveedor proveedor, UpdateProveedorDto dto)
        {
            proveedor.RazonSocial = dto.RazonSocial;
            proveedor.CUIT = dto.CUIT;
            proveedor.CodigoProveedor = dto.CodigoProveedor;
            proveedor.Telefono = dto.Telefono;
            proveedor.Correo = dto.Correo;

            // No se actualiza Compras aquí — eso lo maneja otra capa
        }
    }
}
