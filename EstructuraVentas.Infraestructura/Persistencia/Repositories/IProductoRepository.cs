using EstructuraVentas.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructuraVentas.Infraestructura.Persistencia.Repositories
{
    public interface IProductoRepository
    {

        Task AgregarProductoAsync(Producto producto);

        Task EliminarProductoAsync(int IdProducto);

        Task ModificarProductoAsync(Producto producto);

        Task<List<Producto>> MostrarProductoAsync();

        Task<Producto?> ObtenerPorIdProductoAsync(int IdProducto);

    }
}
