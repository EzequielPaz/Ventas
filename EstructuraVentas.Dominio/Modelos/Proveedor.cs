using MongoDB.Bson.Serialization.Attributes;

namespace EstructuraVentas.Dominio.Modelos
{
    public class Proveedor
    {
        [BsonId]
        public int IdProveedor { get; set; }   // seguimos usando int

        [BsonElement("RazonSocial")]
        public string RazonSocial { get; set; }

        [BsonElement("CUIT")]
        public string CUIT { get; set; }

        [BsonElement("CodigoProveedor")]
        public string CodigoProveedor { get; set; }

        [BsonElement("Telefono")]
        public string Telefono { get; set; }

        [BsonElement("Correo")]
        public string Correo { get; set; }

        [BsonElement("FechaDeRegistro")]
        public DateTime FechaDeRegistro { get; set; } = DateTime.Now;

        [BsonIgnore]
        public ICollection<Compra> Compras { get; set; } = new List<Compra>() { };

    }
}
