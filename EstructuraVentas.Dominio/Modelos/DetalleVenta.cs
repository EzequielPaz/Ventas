using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructuraVentas.Dominio.Modelos
{
    public class DetalleVenta
    {
        
        [Key]
        public int IdDetalleVenta { get; set; }

        [Required]
        public int VentaId { get; set; }                    // FK de clase Venta

        public Venta Venta { get; set; }                  // Navegación a Venta

        [Required]
        public int IdProducto { get; set; }                 // FK a Producto

        public Producto Producto { get; set; }              // Navegación a Producto

        [Required]
        public int Cantidad { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal PrecioUnitario { get; set; }

        [NotMapped]
        public decimal SubtotalVenta => Cantidad * PrecioUnitario;
    }
}

