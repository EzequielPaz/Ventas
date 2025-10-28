using EstructuraVentas.Dominio;
using EstructuraVentas.Dominio.Modelos;
using EstructuraVentas.Infraestructura.Persistencia.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructuraVentas.LogicaNegocio.Servicios
{
    public class CategoriaServicio
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaServicio(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public async Task AgregarCategoria(Categoria categoria)
        {
            if (categoria == null)
                throw new ArgumentNullException(nameof(categoria));

            try
            {
                await _categoriaRepository.agregarCategoriaAsync(categoria);
                await _categoriaRepository.guardarCambiosAsync();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("unique constraint") || ex.Message.Contains("duplicate"))
                    throw new InvalidOperationException("La categoría ya existe.", ex);
                throw;
            }
        }

        public async Task<List<Categoria>> ObtenerTodas()
        {
            return await _categoriaRepository.ObtenerTodas();
        }

    }

}
