using EstructuraVentas.Dominio;
using EstructuraVentas.Dominio.Modelos;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructuraVentas.Infraestructura.Persistencia.Contexto
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetConnectionString("MongoDb"));
            _database = client.GetDatabase("VentasDb");
        }

        public IMongoDatabase Database => _database;

        public IMongoCollection<Cliente> Clientes => _database.GetCollection<Cliente>("Clientes");
        public IMongoCollection<Producto> Productos => _database.GetCollection<Producto>("Productos");
        public IMongoCollection<Usuario> Usuarios => _database.GetCollection<Usuario>("Usuarios");
        public IMongoCollection<Proveedor> Proveedor => _database.GetCollection<Proveedor>("Proveedores");

    }
}
