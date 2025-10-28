using EstructuraVentas.Dominio.Modelos;
using EstructuraVentas.Infraestructura.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructuraVentas.Infraestructura.Repositories
{
    public class DetalleCompraRepository : IDetalleCompra
    {
        private readonly ApplicationDbContext _context;

        public DetalleCompraRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AgregarDetalleCompraAsync(DetalleCompra detalleCompra)
        {
            await _context.DetalleCompras.AddAsync(detalleCompra);
            _context.SaveChanges(); 
        }

        public async Task EliminarDetalleCompraAsync(int id)
        {
            var detalleCompra = _context.DetalleCompras.FirstOrDefault(u => u.IdDetalleCompra == id);
            _context.DetalleCompras.Remove(detalleCompra);
        }

        public async Task<IEnumerable<DetalleCompra>> MostrarDetallesCompraAsync()
        {
            return await _context.DetalleCompras.ToListAsync();
        }
    }


}
