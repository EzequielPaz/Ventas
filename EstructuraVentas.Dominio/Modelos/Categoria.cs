using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructuraVentas.Dominio.Modelos
{
    public class Categoria
    {
        [Key]
        public int IdCategoria { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        // Relación: Una categoría puede tener muchos productos
        public ICollection<Producto> Productos { get; set; }

        public override string ToString()
        {
            return Nombre;
        }

    }
}
