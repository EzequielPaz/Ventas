using EstructuraVentas.Dominio.Modelos;
using EstructuraVentas.Infraestructura.Persistencia.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructuraVentas.LogicaNegocio.Servicios
{
    public class CompraServicio
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ICompraRepository _compraRepository;


        public CompraServicio(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _compraRepository = _serviceProvider.GetRequiredService<ICompraRepository>();
            
        }


        public async Task agregarCompraAsync(Compra compra)
        {
            await _compraRepository.agregarCompraAsync(compra);
        }

        public async Task<List<Compra>> mostrarComprasAsync()
        {
            try
            {
                var compras = await _compraRepository.mostrarComprasAsync();
                return compras;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error al obtener las compras.", ex);
            }
        }
    }
}
