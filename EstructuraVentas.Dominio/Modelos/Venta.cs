using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructuraVentas.Dominio.Modelos
{
    public class Venta
    {
        public int IdVentas { get; set; }
        public int Precio  { get; set; }
        public int Stock { get; set; }

        public DateTime Fecha { get; set; }

        [Required]
        public int IdCliente { get; set; }                 // FK a Cliente

        public Cliente Cliente { get; set; }              // Navegación a Cliente

        public ICollection<DetalleVenta> Detalles { get; set; } = new List<DetalleVenta>(); //Lista del detalle Venta
    }

}
