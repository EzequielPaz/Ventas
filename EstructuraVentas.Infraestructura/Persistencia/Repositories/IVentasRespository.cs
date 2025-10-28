using EstructuraVentas.Dominio.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructuraVentas.Infraestructura.Persistencia.Repositories
{
    public interface IVentasRespository
    {
        Task AgregarVentaAsync(Venta venta);
        Task ActualizarVentaAsync(Venta venta);
        Task EliminarVentaAsync(int IdVenta);
        Task<Venta> ObtenerVentaPorIdAsync(int idVenta);
        Task<List<Venta>> ObtenerListaVentas();
        
    }
}
