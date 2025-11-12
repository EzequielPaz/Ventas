using EstructuraVentas.Dominio.Modelos;
using EstructuraVentas.LogicaNegocio.DTOs.Categoria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructuraVentas.LogicaNegocio.Mapper
{
    public static class CategoriaMapper
    {
        public static Categoria ToEntity(this CreateCategoriaDTO dto)
        {
            return new Categoria
            {
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion
            };
        }

        public static void UpdateEntity(this Categoria categoria, UpdateCategoriaDTO dto)
        {
            categoria.Nombre = dto.Nombre;
            categoria.Descripcion = dto.Descripcion;
        }

        public static CategoriaDTO ToDTO(this Categoria categoria)
        {
            return new CategoriaDTO
            {
                IdCategoria = categoria.IdCategoria,
                Nombre = categoria.Nombre,
                Descripcion = categoria.Descripcion,
                CantidadProductos = categoria.Productos?.Count ?? 0
            };
        }

    }
}
