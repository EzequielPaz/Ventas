using EstructuraVentas.Dominio.Modelos;
using EstructuraVentas.Infraestructura.Persistencia.Contexto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructuraVentas.Infraestructura.Persistencia.Repositories
{
    public class VentasRepository : IVentasRespository
    {
        private readonly ApplicationDbContext _context;
        public VentasRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task ActualizarVentaAsync(Venta venta)
        {
            var trackedEntity = await _context.Ventas.FindAsync(venta.IdVentas);
            if (trackedEntity != null)
            {
                _context.Entry(trackedEntity).CurrentValues.SetValues(venta);
            }
            else
            {
                _context.Ventas.Update(venta);
            }

            await _context.SaveChangesAsync(); 
        }

        public async Task AgregarVentaAsync(Venta venta)
        {
            _context.Ventas.Add(venta);
            await _context.SaveChangesAsync();
        }

        // Elimina un Venta por ID
        public async Task EliminarVentaAsync(int IdVenta)
        {
            var venta = await _context.Ventas.FindAsync(IdVenta);
            if (venta != null)
            {
                _context.Ventas.Remove(venta);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException("No se encontró la venta a eliminar.");
            }
        }
        public async Task<List<Venta>> ObtenerListaVentas()
        {
            return await _context.Ventas.ToListAsync();
        }

        public async Task<Venta> ObtenerVentaPorIdAsync(int idVenta)
        {
            return await _context.Ventas
                .FirstOrDefaultAsync(u => u.IdVentas == idVenta);
        }
    }
}
