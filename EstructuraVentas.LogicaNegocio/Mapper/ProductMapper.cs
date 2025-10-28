using EstructuraVentas.Dominio;
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
                Estado = EstadoProducto.Activo,
                CategoriaId = dto.CategoriaId
            };
        }

        public static ProductResponseDto ToResponse(this Producto producto)
        {
            return new ProductResponseDto
            {
                Id = producto.IdProducto,
                Nombre = producto.Nombre,
                Descripcion = producto.Descripcion,
                Codigo = producto.Codigo,
                Stock = producto.Stock,
                Marca = producto.Marca,
                Precio = producto.Precio,
                FechaAlta = producto.FechaAlta,
                //Estado = producto.Estado,
                CategoriaId = producto.CategoriaId
            };
        }
    }
}
