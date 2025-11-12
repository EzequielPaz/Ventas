using EstructuraVentas.Dominio;
using EstructuraVentas.Dominio.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructuraVentas.LogicaNegocio.DTOs.Producto
{
    public class ProductResponseDto
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Codigo { get; set; }
        public string Marca { get; set; }
        public int Stock { get; set; }
        public decimal Precio { get; set; }

        // 🔹 Agregá estas dos propiedades si no las tenés
        public int CategoriaId { get; set; }
        public string CategoriaNombre { get; set; }


    }
}
