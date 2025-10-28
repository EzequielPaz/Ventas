using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructuraVentas.Dominio.Modelos
{
    public class Compra
    {
        [Key]
        public int IdCompra { get; set; }
        public DateTime FechaCompra { get; set; } = DateTime.Now;
        public int ProveedorId { get; set; }              // Clave foránea
        public Proveedor Proveedor { get; set; }          // Navegación hacia esa tabla
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalCompra { get; set; }
        public ICollection<DetalleCompra> Detalles { get; set; }


    }
}
