using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructuraVentas.Infraestructura.Commons.Bases.Request
{
    public class ClienteFilterRequest : BaseFilterRequest
    {
        public string? EmailFilter { get; set; } = null;
        public string? DocumentoFilter { get; set; } = null;
        public string? CelularFilter { get; set; } = null;


    }
}
