using EstructuraVentas.Dominio;
using EstructuraVentas.Dominio.Modelos;
using EstructuraVentas.Infraestructura.Persistencia.Contexto;
using EstructuraVentas.Infraestructura.Persistencia.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructuraVentas.Infraestructura.Persistencia.Repositories
{
    public class CategoriaRepository : GenericRepository<Categoria>
    {

        public CategoriaRepository(ApplicationDbContext context) : base(context) { }


        // Obtener Categoria por ID
        public async Task<Categoria?> GetCategoriaById(int id)
        {
            return await GetCategoriaById(id);
        }

        // Registrar Categoria (sin SaveChanges, lo hace UnitOfWork)
        public async Task RegisterCategoria(Categoria categoria)
        {
            await AddAsync(categoria);
        }

        // Editar Categoria (sin SaveChanges, lo hace UnitOfWork)
        public void EditCategoria(Categoria categoria)
        {
            Update(categoria);
        }

        // Eliminar Categoria (sin SaveChanges, lo hace UnitOfWork)
        public void DeleteCategoria(Categoria categoria)
        {
            Remove(categoria);
        }

    }
}
