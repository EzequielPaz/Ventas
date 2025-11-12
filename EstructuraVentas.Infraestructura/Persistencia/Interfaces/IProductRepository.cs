using EstructuraVentas.Dominio;
using EstructuraVentas.Infraestructura.Commons.Bases.Request;
using EstructuraVentas.Infraestructura.Commons.Bases.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructuraVentas.Infraestructura.Persistencia.Interfaces
{
    public interface IProductRepository
    {
        Task<BaseEntityResponse<Producto>> ListProductos(BaseFilterRequest filters);
    }
}
