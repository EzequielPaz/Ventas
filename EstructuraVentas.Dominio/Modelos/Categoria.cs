using EstructuraVentas.Dominio;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EstructuraVentas.Dominio.Modelos
{
    public class Categoria
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CatId { get; set; }

        public int CategoriaId { get; set; } = 0;

        //[BsonElement("Nombre")]
        public string Nombre { get; set; }

        //[BsonElement("Descripcion")]
        public string Descripcion { get; set; }

        public ICollection<Producto> Productos { get; set; }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
