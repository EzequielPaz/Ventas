using EstructuraVentas.Dominio;
using EstructuraVentas.Dominio.Modelos;
using EstructuraVentas.Infraestructura.Commons.Bases.Request;
using EstructuraVentas.Infraestructura.Commons.Bases.Response;
using EstructuraVentas.Infraestructura.Persistencia.Contexto;
using EstructuraVentas.Infraestructura.Persistencia.Interfaces;
using System.Linq.Expressions;

namespace EstructuraVentas.Infraestructura.Persistencia.Repositories { }
//{
//    public class VentaRepository : GenericRepository<Venta>, IVentaRepository
//    {
//        public VentaRepository(ApplicationDbContext context) : base(context)
//        {

//        }

//        //public async Task<BaseEntityResponse<Cliente>> ListClientes(BaseFilterRequest filters)
//        //{
//        //    // Convertimos int? a enum? para poder comparar enum con enum
//        //    Estado? estadoFilter = filters.StateFilter.HasValue
//        //        ? (Estado?)filters.StateFilter.Value
//        //        : null;

//        //    Expression<Func<Cliente, bool>> filtroExtra = c =>
//        //        (string.IsNullOrEmpty(filters.TextFilter) || c.NombreCliente.Contains(filters.TextFilter)) &&
//        //        (!estadoFilter.HasValue || c.Estado == estadoFilter.Value);

//        //    return await ListAsync(filters, filtroExtra);
//        //}

//        public async Task<Venta?> GetVentaById(int id)
//        {
//            return await GetByIdAsync(id);
//        }

//        public async Task AgregarVenta(Venta venta)
//        {
//            await AddAsync(venta);
//        }

//        public void EditarVenta(Venta venta)
//        {
//            Update(venta);
//        }

//        public void EliminarVenta(Venta venta)
//        {
//            Remove(venta);
//        }
//    }
//}
