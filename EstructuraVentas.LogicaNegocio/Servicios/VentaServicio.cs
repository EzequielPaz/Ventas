using EstructuraVentas.Dominio;
using EstructuraVentas.Dominio.Modelos;
using EstructuraVentas.Infraestructura.Persistencia.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructuraVentas.LogicaNegocio.Servicios
{
    public class VentaServicio
    {
        private readonly IVentasRespository _ventasRepository;


        public VentaServicio(IVentasRespository ventaRepository)
        {
            _ventasRepository = ventaRepository ?? throw new ArgumentNullException(nameof(_ventasRepository));
        }

        // Agregar cliente 
        public async Task AgregarVenta(Venta venta) //Funcion
        {

            if (venta == null)
            {
                throw new ArgumentNullException(nameof(venta));
            }

            try
            {
                await _ventasRepository.AgregarVentaAsync(venta);
                //await _ventasRepository.GuardarClienteAsync();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("unique constraint") || ex.Message.Contains("duplicate"))
                    throw new InvalidOperationException("La venta ya existe, ya está en uso.", ex);
                throw;
            }

        }

        //Eliminar Venta
        public async Task EliminarVenta(int idVenta)
        {
            await _ventasRepository.EliminarVentaAsync(idVenta);

        }


        //Modificar Venta
        public async Task ModificarVenta(Venta venta)
        {
            try
            {
                await _ventasRepository.ActualizarVentaAsync(venta);

            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("unique constraint") || ex.Message.Contains("duplicate"))
                    throw new InvalidOperationException("La venta ya está en uso.", ex);
                throw;
            }
        }



        //Mostrar lista Ventas
        public async Task<List<Venta>> MostrarVentasAsync()
        {
            return await _ventasRepository.ObtenerListaVentas();
        }

        //Obtener Ventas por Id 
        public async Task<Venta> ObtenerPorIdVenta(int idVenta)
        {
            return await _ventasRepository.ObtenerVentaPorIdAsync(idVenta);
        }


    }
}
