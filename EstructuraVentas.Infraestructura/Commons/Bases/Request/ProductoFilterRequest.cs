using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructuraVentas.Infraestructura.Commons.Bases.Request
{
    public class ProductoFilterRequest:BaseFilterRequest
    {
        public string? Codigo { get; set; } = null;
        public string? Marca { get; set; } = null;
        public string? Descripcion { get; set; } = null;

    }
}
