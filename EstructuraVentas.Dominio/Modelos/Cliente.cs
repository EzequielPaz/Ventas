using EstructuraVentas.Dominio.Commons.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EstructuraVentas.Dominio
{
    public class Cliente
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string IDClientes { get; set; } = string.Empty;

        public string? NombreCliente { get; set; }
        public string? Email { get; set; }
        public string? Documento { get; set; }
        public string? Celular { get; set; }
        public DateTime FechaDeRegistro { get; set; } = DateTime.Now;
        public Estado Estado { get; set; } = Estado.Activo;

    }

   
}
