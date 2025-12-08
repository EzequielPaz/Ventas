using EstructuraVentas.Dominio.Commons.Enums;
using EstructuraVentas.Dominio.Modelos;
using EstructuraVentas.Infraestructura.Commons.Bases.Request;
using EstructuraVentas.Infraestructura.Commons.Bases.Response;
using EstructuraVentas.Infraestructura.Persistencia.Interfaces;
using EstructuraVentas.LogicaNegocio.DTOs.Proveedor;
using EstructuraVentas.LogicaNegocio.Mapper;
using EstructuraVentas.LogicaNegocio.Validators.Proveedor;
using FluentValidation;
using System.Linq.Expressions;

namespace EstructuraVentas.LogicaNegocio.Servicios
{
    public class ProveedorServicio
    {
        //variables de clase
        private readonly IUnitOfWork _unitOfWork;
        private readonly CreateProveedorDtoValidator _validatorCreate;
        private readonly UpdateProveedorDtoValidator _validatorUpdate;

        //CONSTRUCTOR
        public ProveedorServicio(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _validatorCreate = new CreateProveedorDtoValidator();
            _validatorUpdate = new UpdateProveedorDtoValidator();
        }

        //Agregar proveedor

        public async Task AgregarProveedorAsync(CreateProveedorDTO dto) 
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            var resultado = _validatorCreate.Validate(dto);
            if (!resultado.IsValid)
                throw new ValidationException(resultado.Errors);

            // 🔥 VALIDAR DOCUMENTO ÚNICO
            //if (await _unitOfWork.Clientes.DocumentoExisteAsync(dto.Documento))
            //    throw new ValidationException("El documento ya está registrado.");

            var proveedor = dto.ToEntity();

            await _unitOfWork.Proveedores.AddAsync(proveedor);

        }

        //Muestra todos en el data grid view 

        public async Task<BaseEntityResponse<Proveedor>> MostrarProveedores(ProveedorFilterRequest? filters = null)
        {
            filters ??= new ProveedorFilterRequest();

            Estado? estadoFilter = null;
            if (filters.StateFilter.HasValue)
                estadoFilter = (Estado)filters.StateFilter.Value;

            // ❤️ Mongo sí permite expresiones pero SIN EF.Functions
            Expression<Func<Proveedor, bool>> filtroExtra = p =>
            (string.IsNullOrEmpty(filters.RazonSocialFilter) ||
                p.RazonSocial.Contains(filters.RazonSocialFilter))

            && (string.IsNullOrEmpty(filters.CodigoProveedorFilter) ||
                p.CodigoProveedor.Contains(filters.CodigoProveedorFilter))

            && (string.IsNullOrEmpty(filters.CUILTFilter) ||
                p.CUIT.Contains(filters.CUILTFilter))

            && (string.IsNullOrEmpty(filters.TelefonoFilter) ||
                p.Telefono.Contains(filters.TelefonoFilter))

            && (!estadoFilter.HasValue || p.Estado == estadoFilter.Value);


            var response = await _unitOfWork.Proveedores.ListAsync(filters, filtroExtra);

            return response;
        }

       

        //Edita el proveedor 
        public async Task ModificarProveedorAsync(UpdateProveedorDTO dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            var validacion = _validatorUpdate.Validate(dto);
            if (!validacion.IsValid)
                throw new ValidationException(validacion.Errors);

            var proveedorExistente = await _unitOfWork.Proveedores.GetByIdAsync(dto.IdProveedor);

            if (proveedorExistente == null)
                throw new KeyNotFoundException("El Proveedor no existe");

            //VALIDAR DOCUMENTO EN OTRO CLIENTE
            //if (await _unitOfWork.Clientes.DocumentoExisteEnOtroAsync(dto.Documento, dto.IDClientes))
            //    throw new ValidationException("El documento ya pertenece a otro cliente.");

            proveedorExistente.UpdateEntity(dto);

            await _unitOfWork.Proveedores.UpdateAsync(proveedorExistente.IdProveedor, proveedorExistente);
        }

        //Elimina el proveedor
        public async Task EliminarProveedorAsync(string idProveedor)
        {
            var proveedor = await _unitOfWork.Proveedores.GetByIdAsync(idProveedor);
            if (proveedor == null)
                throw new KeyNotFoundException("El Proveedor no existe");

            await _unitOfWork.Proveedores.RemoveAsync(idProveedor);
        }

        // ----------------- Obtener proveedor por Id -----------------
        public async Task<Proveedor> ObtenerPorIdProveedorAsync(string idProveedor)
        {
            var proveedor = await _unitOfWork.Proveedores.GetByIdAsync(idProveedor);
            if (proveedor == null)
                throw new KeyNotFoundException("El Proveedor no existe");

            return proveedor;
        }

    }
}
