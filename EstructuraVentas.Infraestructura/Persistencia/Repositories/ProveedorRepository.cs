using EstructuraVentas.Dominio.Modelos;
using EstructuraVentas.Infraestructura.Persistencia.Contexto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructuraVentas.Infraestructura.Persistencia.Repositories
{
    //Esta clase implementa la interfaz IProveedorRepository para manejar operaciones CRUD sobre la entidad Proveedor
    //dentro de una base de datos usando Entity Framework 


    public class ProveedorRepository: IProveedorRepository
    {
        private readonly ApplicationDbContext _context;
        //Constructor 
        public ProveedorRepository(ApplicationDbContext context) 
        {
            _context = context;
        
        }
        public async Task agregarProveedorAsync(Proveedor proveedor)
        {
            _context.Proveedores.Add(proveedor);
            await _context.SaveChangesAsync();

        }

        //IQueryable<Proveedor> es una interfaz que representa una consulta a la base de datos que aún no se ha ejecutado
        public IQueryable<Proveedor> Proveedores => _context.Proveedores.AsNoTracking();


        public async Task actualizarProveedorAsync(Proveedor proveedor)
        {

            var trackedEntity = await _context.Proveedores.FindAsync(proveedor.IdProveedor);
            if (trackedEntity != null)
            {
                _context.Entry(trackedEntity).CurrentValues.SetValues(proveedor);
            }
            else
            {
                _context.Proveedores.Update(proveedor);
            }

            await _context.SaveChangesAsync();  // ¡Agrega esta línea!

        }


        public async Task eliminarProveedorAsync(int id)
        {
            var proveedor = await _context.Proveedores.SingleOrDefaultAsync(p => p.IdProveedor == id);
            if (proveedor != null)
            {
                _context.Proveedores.Remove(proveedor);
                await _context.SaveChangesAsync();
            }

        }

        public async Task<List<Proveedor>> mostrarProveedoresAsync()
        {
            return await _context.Proveedores.ToListAsync();

        }

        public async Task<Proveedor> obtenerPorIdAsync(int id)
        {
            var proveedor = await _context.Proveedores
        .FirstOrDefaultAsync(u => u.IdProveedor == id);

            return proveedor; // Si no lo encuentra, devuelve null, averiguar como manejar esto

        }


        public async Task guardarCambiosAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
