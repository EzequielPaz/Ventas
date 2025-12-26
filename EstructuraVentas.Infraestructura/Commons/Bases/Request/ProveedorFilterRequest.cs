using EstructuraVentas.Infraestructura.Commons.Bases.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructuraVentas.Infraestructura.Commons.Bases.Request
{
    public class ProveedorFilterRequest:BaseFilterRequest
    {
        public string? CuitFilter { get; set; }
        public string? RazonSocialFilter { get; set; }
    }
}
