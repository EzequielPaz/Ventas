using EstructuraVentas.Infraestructura.Commons.Bases.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructuraVentas.Infraestructura.Commons.Bases.Request
{
    public class ProveedorFilterRequest: BaseFilterRequest
    {
        public string? CodigoProveedorFilter { get; set; } = null;
        public string? RazonSocialFilter { get; set; } = null;
        public string? CUILTFilter { get; set; } = null;
        public string? TelefonoFilter { get; set; } = null;
    }
}
