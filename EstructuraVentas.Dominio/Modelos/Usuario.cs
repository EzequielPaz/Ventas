using EstructuraVentas.Dominio.Commons.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EstructuraVentas.Dominio.Modelos
{
    public class Usuario
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string NombreUsuario { get; set; } = string.Empty;
        public string ContraseñaHasheada { get; set; } = string.Empty;

        //Con esta propiedad no se guarda en Mongo, parecido al Mapped de entityFramework

        [BsonIgnore]                
        public string Contraseña { get; set; }

        [BsonRepresentation(BsonType.String)]
        public RolDelUsuario RolDelUsuario { get; set; }

        public DateTime FechaDeRegistro { get; set; } = DateTime.Now;

        [BsonRepresentation(BsonType.String)]
        public Estado Estado { get; set; } = Estado.Activo;

    }


    public enum RolDelUsuario
    {
        Admin,
        Gerente,
        Empleado
    }

    
}
