using EstructuraVentas.Dominio.Modelos;
using EstructuraVentas.Infraestructura.Commons.Bases.Request;
using EstructuraVentas.Infraestructura.Commons.Bases.Response;

namespace EstructuraVentas.Infraestructura.Persistencia.Interfaces
{
    public interface IVentaRepository:IGenericRepository<Venta>
    {
        Task<BaseEntityResponse<Venta>> ListaVentas(BaseFilterRequest filters);
    }
}
