using EstructuraVentas.Dominio;
using EstructuraVentas.Infraestructura.Commons.Bases.Request;
using EstructuraVentas.Infraestructura.Commons.Bases.Response;

namespace EstructuraVentas.Infraestructura.Persistencia.Interfaces
{
    public interface IClienteRepository:IGenericRepository<Cliente>
    {
        Task<BaseEntityResponse<Cliente>> ListClientes(BaseFilterRequest filters);

        Task<bool> DocumentoExisteAsync(string documento);
        Task<bool> DocumentoExisteEnOtroAsync(string documento, string idClienteActual);

    }
}
