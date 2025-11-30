using EstructuraVentas.Dominio;
using EstructuraVentas.Dominio.Commons.Enums;

using EstructuraVentas.Infraestructura.Commons.Bases.Request;
using EstructuraVentas.Infraestructura.Commons.Bases.Response;
using EstructuraVentas.Infraestructura.Persistencia.Contexto;
using EstructuraVentas.Infraestructura.Persistencia.Interfaces;
using EstructuraVentas.Infraestructura.Persistencia.Repositories;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using System.Linq.Expressions;

public class ClienteRepository : GenericRepository<Cliente>, IClienteRepository
{
    private readonly IMongoCollection<Cliente> _collection;


    public ClienteRepository(IMongoDatabase database)
    : base(database, "Clientes")
    {
        _collection = database.GetCollection<Cliente>("Clientes");
    }

    /// ================================
    // LISTADO CON FILTROS + PAGINACIÓN
    // ================================
    public async Task<BaseEntityResponse<Cliente>> ListClientes(BaseFilterRequest filters)
    {
        var builder = Builders<Cliente>.Filter;
        var filter = builder.Empty;

        // Buscar por texto (NombreCliente)
        if (!string.IsNullOrEmpty(filters.TextFilter))
        {
            filter &= builder.Regex(c => c.NombreCliente,
                new MongoDB.Bson.BsonRegularExpression(filters.TextFilter, "i"));
        }

        // Filtro por Estado
        if (filters.StateFilter.HasValue)
        {
            Estado estado = (Estado)filters.StateFilter.Value;
            filter &= builder.Eq(c => c.Estado, estado);
        }

        // Contar total
        long totalRecords = await _collection.CountDocumentsAsync(filter);

        // Orden + Paginación
        var result = await _collection.Find(filter)
            .Skip((filters.PageIndex - 1) * filters.PageSize)
            .Limit(filters.PageSize)
            .ToListAsync();

        return new BaseEntityResponse<Cliente>
        {
            TotalRecords = (int)totalRecords,
            Records = result
        };
    }

    // ================================
    // OBTENER POR ID
    // ================================
    public async Task<Cliente?> GetClientById(string id)
    {
        return await _collection.Find(c => c.IDClientes == id).FirstOrDefaultAsync();
    }

    // ================================
    // REGISTRAR CLIENTE
    // ================================
    public async Task RegisterClient(Cliente cliente)
    {
        await _collection.InsertOneAsync(cliente);
    }

    // ================================
    // EDITAR CLIENTE
    // ================================
    public async Task EditClient(Cliente cliente)
    {
        await _collection.ReplaceOneAsync(c => c.IDClientes == cliente.IDClientes, cliente);
    }

    // ================================
    // ELIMINAR CLIENTE
    // ================================
    public async Task DeleteClient(Cliente cliente)
    {
        await _collection.DeleteOneAsync(c => c.IDClientes == cliente.IDClientes);
    }
}
