using EstructuraVentas.Dominio;
using EstructuraVentas.Dominio.Commons.Enums;

using EstructuraVentas.Infraestructura.Commons.Bases.Request;
using EstructuraVentas.Infraestructura.Commons.Bases.Response;
using EstructuraVentas.Infraestructura.Persistencia.Contexto;
using EstructuraVentas.Infraestructura.Persistencia.Interfaces;
using EstructuraVentas.Infraestructura.Persistencia.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

public class ClienteRepository : GenericRepository<Cliente>, IClienteRepository
{
    public ClienteRepository(ApplicationDbContext context) : base(context) { }

    // Listado con filtros y paginación
    public async Task<BaseEntityResponse<Cliente>> ListClientes(BaseFilterRequest filters)
    {
        // Convertimos int? a enum? para poder comparar enum con enum
        Estado? estadoFilter = filters.StateFilter.HasValue
            ? (Estado?)filters.StateFilter.Value
            : null;

        Expression<Func<Cliente, bool>> filtroExtra = c =>
            (string.IsNullOrEmpty(filters.TextFilter) || c.NombreCliente.Contains(filters.TextFilter)) &&
            (!estadoFilter.HasValue || c.Estado == estadoFilter.Value);

        return await ListAsync(filters, filtroExtra);
    }

    // Obtener cliente por ID
    public async Task<Cliente?> GetClientById(int id)
    {
        return await GetByIdAsync(id);
    }

    // Registrar cliente (sin SaveChanges, lo hace UnitOfWork)
    public async Task RegisterClient(Cliente cliente)
    {
        await AddAsync(cliente);
    }

    // Editar cliente (sin SaveChanges, lo hace UnitOfWork)
    public void EditClient(Cliente cliente)
    {
        Update(cliente);
    }

    // Eliminar cliente (sin SaveChanges, lo hace UnitOfWork)
    public void DeleteClient(Cliente cliente)
    {
        Remove(cliente);
    }
}
