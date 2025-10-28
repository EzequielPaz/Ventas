using EstructuraVentas.Dominio.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructuraVentas.Infraestructura.Persistencia.Repositories
{
    public interface IProveedorRepository
    {
        //Task es asíncrono, no devuelve resultado
        Task agregarProveedorAsync(Proveedor proveedor);
        Task actualizarProveedorAsync(Proveedor proveedor);
        Task eliminarProveedorAsync(int id);

        //Retorna una lista de proveedores
        Task<List<Proveedor>> mostrarProveedoresAsync();

        Task<Proveedor> obtenerPorIdAsync(int id);

        Task guardarCambiosAsync();

        //Permite realizar consultas sql
        IQueryable<Proveedor> Proveedores { get; }

    }
}
