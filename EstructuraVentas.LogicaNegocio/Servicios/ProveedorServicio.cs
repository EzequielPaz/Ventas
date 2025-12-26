using EstructuraVentas.Dominio.Modelos;
using EstructuraVentas.Infraestructura.Commons.Bases.Request;
using EstructuraVentas.Infraestructura.Commons.Bases.Response;
using EstructuraVentas.Infraestructura.Persistencia.Interfaces;
using EstructuraVentas.LogicaNegocio.DTOs.Proveedor;
using EstructuraVentas.LogicaNegocio.Validators.Proveedor;
using FluentValidation;

namespace EstructuraVentas.LogicaNegocio.Servicios
{
    public class ProveedorServicio
    {
        private readonly IUnitOfWorkMongo _uow;
        private readonly CreateProveedorValidator _valCreate;
        private readonly UpdateProveedorValidator _valUpdate;


        //CONSTRUCTOR
        public ProveedorServicio(IUnitOfWorkMongo uow)
        {
            _uow = uow;
            _valCreate = new CreateProveedorValidator();
            _valUpdate = new UpdateProveedorValidator();

        }

        // 🔹 Genera ID autoincremental manual para Mongo
        private async Task<int> ObtenerNuevoId()
        {
            var lista = await _uow.Proveedores.GetAsync();
            return lista.Count == 0 ? 1 : lista.Max(x => x.IdProveedor) + 1;
        }


        // ----------------- Agregar -----------------
        public async Task AgregarProveedor(CreateProveedorDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            var validation = _valCreate.Validate(dto);
            if (!validation.IsValid)
                throw new ValidationException(validation.Errors);

            var proveedor = new Proveedor
            {
                IdProveedor = await ObtenerNuevoId(),
                RazonSocial = dto.RazonSocial,
                CUIT = dto.CUIT,
                CodigoProveedor = dto.CodigoProveedor,
                Telefono = dto.Telefono,
                Correo = dto.Correo,
                FechaDeRegistro = DateTime.Now
            };

            await _uow.Proveedores.AddAsync(proveedor);
        }


        // ----------------- FILTROS SIMPLES(sin paginación Mongo) -----------------
        public async Task<BaseEntityResponse<Proveedor>> MostrarProveedores(ProveedorFilterRequest? filters = null)
        {
            filters ??= new ProveedorFilterRequest();

            var (data, total) = await _uow.Proveedores.ListPagedAsync(
                filters.PageIndex,
                filters.Records,
                null
            );

            return new BaseEntityResponse<Proveedor>
            {
                TotalRecords = (int)total,
                Records = data
            };
        }




        public async Task<List<Proveedor>> ObtenerTodos()
        {
            return await _uow.Proveedores.GetAsync();
        }


        public async Task<Proveedor> ObtenerPorId(int id)
        {
            var proveedor = await _uow.Proveedores.GetByIdAsync(id);
            if (proveedor == null)
                throw new KeyNotFoundException("Proveedor no existe");

            return proveedor;
        }


        public async Task Actualizar(UpdateProveedorDto dto)
        {
            var validation = _valUpdate.Validate(dto);
            if (!validation.IsValid)
                throw new ValidationException(validation.Errors);

            var existente = await _uow.Proveedores.GetByIdAsync(dto.IdProveedor);
            if (existente == null)
                throw new KeyNotFoundException("Proveedor no encontrado");

            existente.RazonSocial = dto.RazonSocial;
            existente.CUIT = dto.CUIT;
            existente.CodigoProveedor = dto.CodigoProveedor;
            existente.Telefono = dto.Telefono;
            existente.Correo = dto.Correo;

            await _uow.Proveedores.UpdateAsync(existente, existente.IdProveedor);
        }

        public async Task Eliminar(int id)
        {
            await _uow.Proveedores.DeleteAsync(id);
        }



    }
}
