using EstructuraVentas.Dominio;
using EstructuraVentas.Dominio.Commons.Enums;
using EstructuraVentas.LogicaNegocio.DTOs.Clientes;
using EstructuraVentas.LogicaNegocio.DTOs.Producto;



namespace EstructuraVentas.LogicaNegocio.Mapper
{
    public static class ProductoMapper
    {
        public static Producto ToEntity(this CreateProductDTO dto)
        {
            return new Producto
            {
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                Codigo = dto.Codigo,
                Stock = dto.Stock,
                Marca = dto.Marca,
                Precio = dto.Precio,
                FechaAlta = DateTime.Now,
                Estado = Estado.Activo,
                CategoriaId = dto.CategoriaId
            };
        }

        public static ProductResponseDto ToResponse(this Producto producto)
        {
            return new ProductResponseDto
            {
                IdProducto = producto.IdProducto,
                Nombre = producto.Nombre,
                Descripcion = producto.Descripcion,
                Codigo = producto.Codigo,
                Marca = producto.Marca,
                Stock = producto.Stock,
                Precio = producto.Precio,
                CategoriaId = producto.CategoriaId,
                CategoriaNombre = producto.Categoria != null ? producto.Categoria.Nombre : string.Empty
            };

        }

        public static void UpdateEntity(this Producto producto, UpdateProductDTO dto)
        {
            producto.Nombre = dto.Nombre;
            producto.Descripcion = dto.Descripcion;
            producto.Codigo = dto.Codigo;
            producto.Marca = dto.Marca;
            producto.Precio = dto.Precio;
            producto.Stock = dto.Stock;
            producto.CategoriaId = dto.CategoriaId;

        }
    }
}
