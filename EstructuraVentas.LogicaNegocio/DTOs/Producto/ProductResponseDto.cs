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
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Codigo { get; set; }
        public int Stock { get; set; }
        public string Marca { get; set; }
        public decimal Precio { get; set; }
        public DateTime FechaAlta { get; set; }

        // Mejor como string para exponer en la API
        public string Estado { get; set; }

        public int CategoriaId { get; set; }

        // Opcional: mostrar también el nombre de la categoría
        public string CategoriaNombre { get; set; }


    }
}
