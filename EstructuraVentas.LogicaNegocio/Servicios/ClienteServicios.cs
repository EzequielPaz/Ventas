using EstructuraVentas.Dominio;
using EstructuraVentas.Infraestructura.Commons.Bases.Request;
using EstructuraVentas.Infraestructura.Commons.Bases.Response;
using EstructuraVentas.Infraestructura.Persistencia.Interfaces;
using EstructuraVentas.LogicaNegocio.DTOs.Clientes;
using EstructuraVentas.LogicaNegocio.Mapper;
using EstructuraVentas.LogicaNegocio.Validators.Cliente;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EstructuraVentas.LogicaNegocio.Servicios
{
    public class ClienteServicios
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly CreateClientDTOValidator _validatorCreate;
        private readonly UpdateClienteDTOValidator _validatorUpdate;


        public ClienteServicios(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _validatorCreate = new CreateClientDTOValidator();
            _validatorUpdate = new UpdateClienteDTOValidator();
        }

        // ----------------- Agregar Cliente -----------------
        public async Task AgregarCliente(CreateClienteDTO dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            var resultado = _validatorCreate.Validate(dto);
            if (!resultado.IsValid)
                throw new ValidationException(resultado.Errors);

            var cliente = dto.ToEntity();

            await _unitOfWork.Clientes.AddAsync(cliente);
            await _unitOfWork.SaveChangesAsync(); // ✅ Esperamos que termine
        }

        // ----------------- Mostrar Clientes -----------------
        public async Task<BaseEntityResponse<Cliente>> MostrarClientes(ClienteFilterRequest? filters = null)
        {
            // Ahora, filters será de tipo ClienteFilterRequest, asegurando que tiene las nuevas propiedades.
            filters ??= new ClienteFilterRequest();

            Estado? estadoFilter = null;

            if (filters.StateFilter.HasValue && Enum.IsDefined(typeof(Estado), filters.StateFilter.Value))
                estadoFilter = (Estado)filters.StateFilter.Value;

            // Adaptamos la expresión de filtrado para usar los nuevos campos
            Expression<Func<Cliente, bool>> filtroExtra = c =>
                // FILTRO 1: Por NombreCliente (usando TextFilter general)
                (string.IsNullOrEmpty(filters.TextFilter) ||
                 EF.Functions.Like(c.NombreCliente ?? "", $"%{filters.TextFilter}%"))

                &&

                // FILTRO 2: Por Email (usando el nuevo EmailFilter)
                (string.IsNullOrEmpty(filters.EmailFilter) ||
                 EF.Functions.Like(c.Email ?? "", $"%{filters.EmailFilter}%"))

                &&

                // FILTRO 3: Por Documento (DNI) (usando el nuevo DocumentoFilter)
                (string.IsNullOrEmpty(filters.DocumentoFilter) ||
                 EF.Functions.Like(c.Documento ?? "", $"%{filters.DocumentoFilter}%"))

                &&

                // FILTRO 4: Por Estado (heredado de BaseFilterRequest)
                (!estadoFilter.HasValue || c.Estado == estadoFilter.Value);

            var response = await _unitOfWork.Clientes.ListAsync(filters, filtroExtra);

            Console.WriteLine($"Clientes encontrados: {response.TotalRecords}");
            return response;
        }

        // ----------------- Modificar Cliente -----------------
        public async Task ModificarClienteAsync(UpdateClienteDTO dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            var resultadoValidacion = _validatorUpdate.Validate(dto);
            if (!resultadoValidacion.IsValid)
                throw new ValidationException(resultadoValidacion.Errors);

            var clienteExistente = await _unitOfWork.Clientes.GetByIdAsync(dto.IDClientes);
            if (clienteExistente == null)
                throw new KeyNotFoundException("El cliente no existe");

            clienteExistente.UpdateEntity(dto);

            _unitOfWork.Clientes.Update(clienteExistente);
            await _unitOfWork.SaveChangesAsync(); // ✅ Esperamos que termine antes de otra operación
        }

        // ----------------- Eliminar Cliente -----------------
        public async Task EliminarClienteAsync(int idCliente)
        {
            var cliente = await _unitOfWork.Clientes.GetByIdAsync(idCliente);
            if (cliente == null)
                throw new KeyNotFoundException("El cliente no existe");

            _unitOfWork.Clientes.Remove(cliente);
            await _unitOfWork.SaveChangesAsync(); // ✅ Esperamos que termine antes de otra operación
        }

        // ----------------- Obtener Cliente por Id -----------------
        public async Task<Cliente> ObtenerPorIdClienteAsync(int idCliente)
        {
            var cliente = await _unitOfWork.Clientes.GetByIdAsync(idCliente);
            if (cliente == null)
                throw new KeyNotFoundException("El cliente no existe");

            return cliente;
        }
    }



}
