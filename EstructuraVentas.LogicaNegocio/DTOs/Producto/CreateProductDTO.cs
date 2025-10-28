using EstructuraVentas.Dominio.Modelos;
using System.ComponentModel.DataAnnotations.Schema;

namespace EstructuraVentas.LogicaNegocio.DTOs.Producto
{
    public class CreateProductDTO
    {
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public string Codigo { get; set; }

        public int Stock { get; set; }

        public string Marca { get; set; }

        public decimal Precio { get; set; }

        public int CategoriaId { get; set; }

        // Propiedad de navegación
        [ForeignKey("CategoriaId")]
        public Categoria Categoria { get; set; }
    }
}
