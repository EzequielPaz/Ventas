using EstructuraVentas.Dominio.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructuraVentas.Infraestructura.Repositories
{
    public interface ICompraRepository
    {
        Task agregarCompraAsync(Compra compra);
        Task<Compra> obtenerPorIdAsync(int id);
        Task<List<Compra>> mostrarComprasAsync();

    }
}
