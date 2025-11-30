using EstructuraVentas.Dominio.Commons.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EstructuraVentas.Dominio.Modelos
{
    public class Usuario
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string IdUsuario { get; set; }

        public string NombreUsuario { get; set; }
        public string ContraseñaHasheada { get; set; } = string.Empty;

        [BsonIgnore]                //Con esta propiedad no se guarda en Mongo, parecido al Mapped de entityFramework
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
