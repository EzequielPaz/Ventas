using EstructuraVentas.Dominio.Modelos;
using EstructuraVentas.Dominio.Validators;
using EstructuraVentas.Infraestructura.Persistencia.Repositories;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EstructuraVentas.LogicaNegocio.Servicios
{
    public class ProveedorServicio
    {
        //variables de clase
        private readonly IServiceProvider _serviceProvider;
        private readonly IProveedorRepository _proveedorRepository;
        private readonly ProveedorValidator _validator;

        //CONSTRUCTOR
        public ProveedorServicio(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _proveedorRepository = _serviceProvider.GetRequiredService<IProveedorRepository>();
            _validator = new ProveedorValidator();
        }

        //Agregar proveedor

        public async Task agregarProveedorAsync(Proveedor proveedor) 
        {
            var resultado = _validator.Validate(proveedor);

            if (!resultado.IsValid)
            {
                var errores = string.Join(Environment.NewLine, resultado.Errors.Select(e => e.ErrorMessage));
                throw new ValidationException(errores);
            }

            await _proveedorRepository.agregarProveedorAsync(proveedor);
         
        }

        //Muestra todos en el data grid view 

        public async Task<List<Proveedor>> mostrarProveedoresAsync()
        {
            try
            {
                var proveedores = await _proveedorRepository.mostrarProveedoresAsync();
                return proveedores;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error al obtener los proveedores.", ex);
            }
        }

        //Obtiene el proveedor por su id 
        public async Task<Proveedor> obtenerProveedorPorId(int id)
        {
            return await _proveedorRepository.Proveedores
        .AsNoTracking()
        .FirstOrDefaultAsync(p => p.IdProveedor == id);

        }

        //Edita el proveedor 
        public async Task ActualizarProveedorAsync(Proveedor proveedor)
        {
            await _proveedorRepository.actualizarProveedorAsync(proveedor);
            await _proveedorRepository.guardarCambiosAsync();
        }

        //Elimina el proveedor
        public async Task EliminarProveedorAsync(int id)
        {
            await _proveedorRepository.eliminarProveedorAsync(id);
            await _proveedorRepository.guardarCambiosAsync();
        }

    }
}
