using EstructuraVentas.Dominio;
using EstructuraVentas.Infraestructura.Persistencia.Repositories;
using EstructuraVentas.LogicaNegocio.DTOs.Producto;
using EstructuraVentas.LogicaNegocio.Mapper;

namespace EstructuraVentas.LogicaNegocio.Servicios
{
    public class ProductoServicios
    {
        private readonly IProductoRepository _productoRepository;
    


        public ProductoServicios(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
            
        }

        //Agregar Producto

        public async Task<ProductResponseDto> AgregarProducto(CreateProductDTO dto) 
        {
            if(dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

          
            try
            {
                var producto = dto.ToEntity(); // de DTO a Entidad
                await _productoRepository.AgregarProductoAsync(producto);
                return producto.ToResponse();  // de Entidad a ResponseDTO

            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("unique constraint") || ex.Message.Contains("duplicate"))
                    throw new InvalidOperationException("El nombre del producto ya está en uso.", ex);
                throw;

            }
        }


        //Eliminar Producto
        public async Task EliminarProducto(int idProducto)
        {
            await _productoRepository.EliminarProductoAsync(idProducto);
         
        }

        //Modificar Producto
        public async Task ModificarProducto(Producto producto)
        {
            try
            {
                await _productoRepository.ModificarProductoAsync(producto);

            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("unique constraint") || ex.Message.Contains("duplicate"))
                    throw new InvalidOperationException("El nombre del producto ya está en uso.", ex);
                throw;
            }
        }

        //Mostrar Producto en grilla
        public async Task<List<Producto>> MostrarProductoAsync()
        {
            return await _productoRepository.MostrarProductoAsync();
        }

        //Obtener Producto por Id 
        public async Task<Producto> ObtenerPorIdProducto(int idProducto)
        {
            return await _productoRepository.ObtenerPorIdProductoAsync(idProducto);
        }


    }
}
