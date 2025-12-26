using EstructuraVentas.Dominio;
using EstructuraVentas.Dominio.Modelos;
using EstructuraVentas.Infraestructura.Persistencia.Utils;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Driver.Core.Configuration;


namespace EstructuraVentas.Infraestructura.Persistencia.Contexto
{
    public class MongoContext
    {
        private readonly IMongoDatabase _database;

        public MongoContext(IOptions<MongoDbSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            _database = client.GetDatabase(settings.Value.DatabaseName);
        }

        // Método para obtener colecciones
        public IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            return _database.GetCollection<T>(collectionName);
        }

        // Método de prueba
        public void TestConnection()
        {
            var collections = _database.ListCollectionNames().ToList();
            Console.WriteLine("Mongo conectado. Colecciones: " + string.Join(", ", collections));
        }




    }
}
