using EstructuraVentas.Dominio.Modelos;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EstructuraVentas.Dominio.Commons.Enums;


namespace EstructuraVentas.Dominio
{
    public class Producto
    {
        [Required]
        [Key]
        public int IdProducto { get; set; }

        [Required, StringLength(100)]
        
        public string? Nombre { get; set; }

        public string? Descripcion { get; set; }

        [Required, StringLength(50)]
        public string? Codigo { get; set; }

        [Range(0, int.MaxValue)]
        public int Stock { get; set; }

        public string? Marca { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Precio { get; set; }

        public DateTime FechaAlta { get; set; } = DateTime.Now;

        public Estado Estado { get; set; } = Estado.Activo;

        // Clave foránea
        public int CategoriaId { get; set; }

        // Propiedad de navegación
        [ForeignKey("CategoriaId")]
        public Categoria? Categoria { get; set; }
    }

    
}
