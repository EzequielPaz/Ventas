using EstructuraVentas.Dominio;
using EstructuraVentas.Dominio.Commons.Enums;

using EstructuraVentas.Infraestructura.Commons.Bases.Request;
using EstructuraVentas.Infraestructura.Commons.Bases.Response;
using EstructuraVentas.Infraestructura.Persistencia.Interfaces;
using EstructuraVentas.LogicaNegocio.DTOs.Categoria;
using EstructuraVentas.LogicaNegocio.DTOs.Producto;
using EstructuraVentas.LogicaNegocio.Mapper;
using EstructuraVentas.LogicaNegocio.Validators;
using EstructuraVentas.LogicaNegocio.Validators.Producto;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EstructuraVentas.LogicaNegocio.Servicios
{
    public class ProductoServicios
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly CreateProductDtoValidator _validatorCreate;
        private readonly UpdateProducDtoValidator _validatorUpdate;

        public ProductoServicios(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _validatorCreate = new CreateProductDtoValidator();
            _validatorUpdate = new UpdateProducDtoValidator();

        }

        //Agregar Producto

        public async Task<ProductResponseDto> AgregarProducto(CreateProductDTO dto) 
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            var resultado = _validatorCreate.Validate(dto);
            if (!resultado.IsValid)
                throw new ValidationException(resultado.Errors);

            var producto = dto.ToEntity();

            await _unitOfWork.Productos.AddAsync(producto);
            await _unitOfWork.SaveChangesAsync();

            return producto.ToResponse();
        }


        
        public async Task EliminarProducto(int idProducto)
        {
            var producto = await _unitOfWork.Productos.GetByIdAsync(idProducto);
            if (producto == null)
                throw new KeyNotFoundException("El producto no existe");

            _unitOfWork.Productos.Remove(producto);
            await _unitOfWork.SaveChangesAsync(); // ✅ Esperamos que termine antes de otra operación

        }

        //Modificar Producto
        public async Task ModificarProducto(UpdateProductDTO dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            var resultadoValidacion = _validatorUpdate.Validate(dto);
            if (!resultadoValidacion.IsValid)
                throw new ValidationException(resultadoValidacion.Errors);

            var productoExistente = await _unitOfWork.Productos.GetByIdAsync(dto.IdProducto);
            if (productoExistente == null)
                throw new KeyNotFoundException("El producto no existe");

            productoExistente.UpdateEntity(dto);

            _unitOfWork.Productos.Update(productoExistente);
            await _unitOfWork.SaveChangesAsync(); // ✅ Esperamos que termine antes de otra operación
        }

        //Mostrar Producto en grilla
        public async Task<BaseEntityResponse<Producto>> MostrarProductos(ProductoFilterRequest? filters = null)
        {
            filters ??= new ProductoFilterRequest();

            Estado? estadoFilter = filters.StateFilter.HasValue &&
                                   Enum.IsDefined(typeof(Estado), filters.StateFilter.Value)
                ? (Estado)filters.StateFilter.Value
                : null;

            Expression<Func<Producto, bool>> filtroExtra = p =>
                (string.IsNullOrEmpty(filters.TextFilter) ||
                 EF.Functions.Like(p.Nombre ?? string.Empty, $"%{filters.TextFilter}%")) &&
                (string.IsNullOrEmpty(filters.Codigo) ||
                 EF.Functions.Like(p.Codigo ?? string.Empty, $"%{filters.Codigo}%")) &&
                (!estadoFilter.HasValue || p.Estado == estadoFilter.Value);

            // 🔹 Incluir categoría para mostrar su nombre en la grilla
            var response = await _unitOfWork.Productos.ListAsync(
                filters,
                filtroExtra,
                include: q => q.Include(p => p.Categoria)
            );

            return response;

        }

        // ----------------- Obtener Cliente por Id -----------------
        public async Task<ProductResponseDto> ObtenerPorIdProductoeAsync(int idProducto)
        {
            var producto = await _unitOfWork.Productos.GetByIdAsync(
        idProducto,
        include: q => q.Include(p => p.Categoria)
    );

            if (producto == null)
                throw new KeyNotFoundException("El producto no existe");

            return producto.ToResponse();


        }

        public async Task<IEnumerable<CategoriaDTO>> ObtenerCategoriasAsync()
        {
            var categorias = await _unitOfWork.Categorias.GetAllAsync();
            return categorias.Select(c => new CategoriaDTO
            {
                IdCategoria = c.IdCategoria,
                Nombre = c.Nombre
            });
        }



    }
}
