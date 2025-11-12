using System.ComponentModel.DataAnnotations;

namespace EstructuraVentas.Dominio.Modelos
{
    public class Venta
    {
        public int IdVentas { get; set; }
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "El precio debe ser mayor o igual a 0.")]
        public decimal Precio { get; set; }

        public DateTime Fecha { get; set; } = DateTime.Now;


        [Required]
        public int IdCliente { get; set; }                 // FK a Cliente

        public Cliente? Cliente { get; set; }              // Navegación a Cliente

        public ICollection<DetalleVenta> Detalles { get; set; } = new List<DetalleVenta>(); //Lista del detalle Venta
    }

}
