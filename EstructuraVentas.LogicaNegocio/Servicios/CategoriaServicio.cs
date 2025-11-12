using EstructuraVentas.Dominio;
using EstructuraVentas.Dominio.Modelos;
using EstructuraVentas.Infraestructura.Commons.Bases.Request;
using EstructuraVentas.Infraestructura.Commons.Bases.Response;
using EstructuraVentas.Infraestructura.Persistencia.Interfaces;
using EstructuraVentas.Infraestructura.Persistencia.Repositories;
using EstructuraVentas.LogicaNegocio.DTOs.Categoria;
using EstructuraVentas.LogicaNegocio.DTOs.Clientes;
using EstructuraVentas.LogicaNegocio.Mapper;
using EstructuraVentas.LogicaNegocio.Validators.Categoria;
using EstructuraVentas.LogicaNegocio.Validators.Cliente;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EstructuraVentas.LogicaNegocio.Servicios
{
    public class CategoriaServicio
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly CreateCategoriaDTOValidator _validatorCreate;
        private readonly UpdateCategoriaDTOValidator _validatorUpdate;

        public CategoriaServicio(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _validatorCreate = new CreateCategoriaDTOValidator();
            _validatorUpdate = new UpdateCategoriaDTOValidator();
        }

        // ----------------- Agregar Categoría -----------------
        public async Task AgregarCategoriaAsync(CreateCategoriaDTO dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            var resultado = _validatorCreate.Validate(dto);
            if (!resultado.IsValid)
                throw new ValidationException(resultado.Errors);

            var categoria = dto.ToEntity();

            await _unitOfWork.Categorias.AddAsync(categoria);
            await _unitOfWork.SaveChangesAsync();
        }

        // ----------------- Mostrar Categorías -----------------
        public async Task<BaseEntityResponse<Categoria>> MostrarCategoriasAsync(BaseFilterRequest? filters = null)
        {
            filters ??= new BaseFilterRequest();

            Expression<Func<Categoria, bool>> filtro = c =>
                string.IsNullOrEmpty(filters.TextFilter) ||
                EF.Functions.Like(c.Nombre, $"%{filters.TextFilter}%");

            var response = await _unitOfWork.Categorias.ListAsync(
            filters,
            filtro,
            include: q => q.Include(c => c.Productos)
            );

            return response;
        }

        // ----------------- Modificar Categoría -----------------
        public async Task ModificarCategoriaAsync(UpdateCategoriaDTO dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            var resultado = _validatorUpdate.Validate(dto);
            if (!resultado.IsValid)
                throw new ValidationException(resultado.Errors);

            var categoriaExistente = await _unitOfWork.Categorias.GetByIdAsync(dto.IdCategoria);
            if (categoriaExistente == null)
                throw new KeyNotFoundException("La categoría no existe");

            categoriaExistente.UpdateEntity(dto);
            _unitOfWork.Categorias.Update(categoriaExistente);

            await _unitOfWork.SaveChangesAsync();
        }

        // ----------------- Eliminar Categoría -----------------
        public async Task EliminarCategoriaAsync(int idCategoria)
        {
            var categoria = await _unitOfWork.Categorias.GetByIdAsync(idCategoria);
            if (categoria == null)
                throw new KeyNotFoundException("La categoría no existe");

            _unitOfWork.Categorias.Remove(categoria);
            await _unitOfWork.SaveChangesAsync();
        }

        // ----------------- Obtener Categoría por Id -----------------
        public async Task<CategoriaDTO> ObtenerPorIdCategoriaAsync(int idCategoria)
        {
            var categoria = await _unitOfWork.Categorias
                .GetByIdAsync(idCategoria, include: q => q.Include(c => c.Productos));

            if (categoria == null)
                throw new KeyNotFoundException("La categoría no existe");

            return categoria.ToDTO();
        }

    }

}
