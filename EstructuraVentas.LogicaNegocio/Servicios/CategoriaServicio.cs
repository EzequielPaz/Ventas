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
using MongoDB.Bson;
using MongoDB.Driver;
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

        //----------------- Método para obtener el siguiente CategoriaId -----------------
        private async Task<int> GetNextCategoriaIdAsync()
        {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", "categoriaid");
            var update = Builders<BsonDocument>.Update.Inc("sequence_value", 1);

            var options = new FindOneAndUpdateOptions<BsonDocument>
            {
                ReturnDocument = ReturnDocument.After,
                IsUpsert = true
            };

            // Suponiendo que tu _unitOfWork tiene acceso a la DB
            var countersCollection = _unitOfWork.Database.GetCollection<BsonDocument>("counters");
            var result = await countersCollection.FindOneAndUpdateAsync(filter, update, options);

            return result["sequence_value"].AsInt32;
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

            // Asignar CategoriaId autoincremental
            categoria.CategoriaId = await GetNextCategoriaIdAsync();

            await _unitOfWork.Categorias.AddAsync(categoria);
            await _unitOfWork.SaveChangesAsync();
        }
        /*
        // ----------------- Mostrar Categorías -----------------
        public async Task<BaseEntityResponse<Categoria>> MostrarCategoriasAsync(BaseFilterRequest? filters = null)
        {
            filters ??= new BaseFilterRequest();

            Expression<Func<Categoria, bool>> filtro = c =>
                string.IsNullOrEmpty(filters.TextFilter) ||
                c.Nombre.ToLower().Contains(filters.TextFilter.ToLower());

            // ACÁ la llamada correcta
            var response = await _unitOfWork.Categorias.ListAsync(filters, filtro);

            return response;
        }
        */

        // ----------------- Mostrar Categorías -----------------
        public async Task<BaseEntityResponse<CategoriaDTO>> MostrarCategoriasAsync(BaseFilterRequest? filters = null)
        {
            filters ??= new BaseFilterRequest();

            Expression<Func<Categoria, bool>> filtro = c =>
                string.IsNullOrEmpty(filters.TextFilter) ||
                c.Nombre.ToLower().Contains(filters.TextFilter.ToLower());

            var categorias = await _unitOfWork.Categorias.ListAsync(filters, filtro);

            return new BaseEntityResponse<CategoriaDTO>
            {
                TotalRecords = categorias.TotalRecords,
                Records = categorias.Records.Select(c => new CategoriaDTO
                {
                    CatId = c.CatId,
                    CategoriaId = c.CategoriaId,
                    Nombre = c.Nombre,
                    Descripcion = c.Descripcion,
                    CantidadProductos = c.Productos?.Count ?? 0
                }).ToList()
            };
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
            await _unitOfWork.Categorias.UpdateAsync(categoriaExistente.CatId, categoriaExistente);



            await _unitOfWork.SaveChangesAsync();
        }

        // ----------------- Eliminar Categoría -----------------
        public async Task EliminarCategoriaAsync(string CatId)
        {
            var categoria = await _unitOfWork.Categorias.GetByIdAsync(CatId);
            if (categoria == null)
                throw new KeyNotFoundException("La categoría no existe");

            await _unitOfWork.Categorias.RemoveAsync(CatId);
            await _unitOfWork.SaveChangesAsync();
        }

        // ----------------- Obtener Categoría por Id -----------------
        public async Task<CategoriaDTO> ObtenerPorIdCategoriaAsync(string CatId)
        {
            var categoria = await _unitOfWork.Categorias.GetByIdAsync(CatId);

            if (categoria == null)
                throw new KeyNotFoundException("La categoría no existe");

            return categoria.ToDTO();
        }

    }

}
