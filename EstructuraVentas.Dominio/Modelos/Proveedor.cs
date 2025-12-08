using EstructuraVentas.Dominio.Commons.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EstructuraVentas.Dominio.Modelos
{
    public class Proveedor
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string IdProveedor { get; set; } = string.Empty;
        public string RazonSocial { get; set; } = string.Empty;
        public string CUIT { get; set; } = string.Empty;
        public string CodigoProveedor { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;

        public Estado Estado { get; set; } = Estado.Activo;

        // REFERENCIA a IDs de la colección Compras
        [BsonRepresentation(BsonType.ObjectId)]
        public List<string> ComprasIds { get; set; } = new();
        public DateTime FechaDeRegistro { get; set; } = DateTime.UtcNow;

    }
}
