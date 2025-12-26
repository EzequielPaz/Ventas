using EstructuraVentas.Dominio.Modelos;
using EstructuraVentas.Infraestructura.Persistencia.Contexto;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace EstructuraVentas.Infraestructura.Persistencia.Repositories
{
    public class CategoriaRepository : GenericRepository<Categoria>
    {
        private readonly IMongoCollection<Categoria> _collection;

        public CategoriaRepository(MongoDbContext context)
            : base(context.Database, "Categorias")
        {
            _collection = context.Database.GetCollection<Categoria>("Categorias");
        }

        // Buscar por CatId (ObjectId como string)
        public async Task<Categoria?> GetCategoriaByCatIdAsync(string catId)
        {
            var filter = Builders<Categoria>.Filter.Eq(c => c.CatId, catId);
            return await _collection.Find(filter).FirstOrDefaultAsync();
        }

        // Buscar por CategoriaId (int)
        public async Task<Categoria?> GetCategoriaByCategoriaIdAsync(int categoriaId)
        {
            var filter = Builders<Categoria>.Filter.Eq(c => c.CategoriaId, categoriaId);
            return await _collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task RegisterCategoriaAsync(Categoria categoria)
        {
            await _collection.InsertOneAsync(categoria);
        }

        public async Task EditCategoriaAsync(Categoria categoria)
        {
            // Reemplaza el documento cuyo CatId coincide
            var filter = Builders<Categoria>.Filter.Eq(c => c.CatId, categoria.CatId);
            await _collection.ReplaceOneAsync(filter, categoria);
        }

        public async Task DeleteCategoriaByCatIdAsync(string catId)
        {
            var filter = Builders<Categoria>.Filter.Eq(c => c.CatId, catId);
            await _collection.DeleteOneAsync(filter);
        }

        public async Task DeleteCategoriaByCategoriaIdAsync(int categoriaId)
        {
            var filter = Builders<Categoria>.Filter.Eq(c => c.CategoriaId, categoriaId);
            await _collection.DeleteOneAsync(filter);
        }
    }
}
