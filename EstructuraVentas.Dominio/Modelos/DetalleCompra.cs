using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructuraVentas.Dominio.Modelos
{
    //Una compra puede tener varios detalles de compra
    public class DetalleCompra
    {
        [Key]
        public int IdDetalleCompra { get; set; }

        [Required]
        public int CompraId { get; set; }                    // FK de clase compra

        public Compra Compra { get; set; }                  // Navegación a Compra

        [Required]
        public int ProductoId { get; set; }                 // FK a Producto

        public Producto Producto { get; set; }              // Navegación a Producto

        [Required]
        public int Cantidad { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal PrecioUnitario { get; set; }

        [NotMapped]
        public decimal SubtotalCompra => Cantidad * PrecioUnitario;
    }
}
