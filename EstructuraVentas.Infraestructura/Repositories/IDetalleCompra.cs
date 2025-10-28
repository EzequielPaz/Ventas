using EstructuraVentas.Dominio.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructuraVentas.Infraestructura.Repositories
{
    public interface IDetalleCompra
    {
        Task AgregarDetalleCompraAsync(DetalleCompra detalleCompra);
        Task EliminarDetalleCompraAsync(int id);
        Task<IEnumerable<DetalleCompra>> MostrarDetallesCompraAsync();

    }
}
