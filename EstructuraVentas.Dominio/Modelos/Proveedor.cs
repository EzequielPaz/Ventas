using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructuraVentas.Dominio.Modelos
{
    public class Proveedor
    {
        [Key]
        public int IdProveedor {  get; set; }
        public string RazonSocial { get; set; }
        public string CUIT {  get; set; }
        public string CodigoProovedor { get; set; }
        public string Telefono {  get; set; }
        public string Correo {  get; set; }

        public ICollection<Compra> Compras { get; set; }

        public DateTime FechaDeRegistro { get; set; } = DateTime.Now;
    }
}
