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
    public class CompraRepository : ICompraRepository
    {
        private readonly ApplicationDbContext _context;

        public CompraRepository(ApplicationDbContext context)
        {
            _context = context;

        }

        public async Task agregarCompraAsync(Compra compra)
        {
            await _context.Compras.AddAsync(compra);
            _context.SaveChanges();
        }

        public async Task<List<Compra>> mostrarComprasAsync()
        {
            return await _context.Compras.ToListAsync();
        }

        public async Task guardarCambiosAsync()
        {
            _context.SaveChanges();
        }
        public async Task<Compra> obtenerPorIdAsync(int id)
        {
            var compra = await _context.Compras
            .FirstOrDefaultAsync(u => u.IdCompra == id);

            return compra; //validar en caso de que devuelva un null
        }


    }
}
