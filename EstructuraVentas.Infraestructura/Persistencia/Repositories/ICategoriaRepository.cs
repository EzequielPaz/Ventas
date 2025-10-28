using EstructuraVentas.Dominio.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructuraVentas.Infraestructura.Persistencia.Repositories
{
    public interface ICategoriaRepository
    {
        Task agregarCategoriaAsync(Categoria categoria);
        Task guardarCambiosAsync();
        Task<List<Categoria>> ObtenerTodas();

    }
}
