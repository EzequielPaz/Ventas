using EstructuraVentas.Dominio;
using EstructuraVentas.Dominio.Commons.Enums;
using EstructuraVentas.Dominio.Modelos;
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
        }


        // ----------------- Mostrar Clientes -----------------
        public async Task<BaseEntityResponse<Cliente>> MostrarClientes(ClienteFilterRequest? filters = null)
        {
            filters ??= new ClienteFilterRequest();

            Estado? estadoFilter = null;
            if (filters.StateFilter.HasValue)
                estadoFilter = (Estado)filters.StateFilter.Value;

            // ❤️ Mongo sí permite expresiones pero SIN EF.Functions
            Expression<Func<Cliente, bool>> filtroExtra = c =>
                (string.IsNullOrEmpty(filters.TextFilter) ||
                 (c.NombreCliente != null && c.NombreCliente.Contains(filters.TextFilter)))

                && (string.IsNullOrEmpty(filters.EmailFilter) ||
                    (c.Email != null && c.Email.Contains(filters.EmailFilter)))

                && (string.IsNullOrEmpty(filters.DocumentoFilter) ||
                    (c.Documento != null && c.Documento.Contains(filters.DocumentoFilter)))

                && (!estadoFilter.HasValue || c.Estado == estadoFilter.Value);

            var response = await _unitOfWork.Clientes.ListAsync(filters, filtroExtra);

            return response;
        }

        // ----------------- Modificar Cliente -----------------
        public async Task ModificarClienteAsync(UpdateClienteDTO dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            var validacion = _validatorUpdate.Validate(dto);
            if (!validacion.IsValid)
                throw new ValidationException(validacion.Errors);

            var clienteExistente = await _unitOfWork.Clientes.GetByIdAsync(dto.IDClientes);

            if (clienteExistente == null)
                throw new KeyNotFoundException("El cliente no existe");

            clienteExistente.UpdateEntity(dto);

            await _unitOfWork.Clientes.UpdateAsync(clienteExistente.IDClientes, clienteExistente);
        }

        // ----------------- Eliminar Cliente -----------------
        public async Task EliminarClienteAsync(string idCliente)
        {
            var cliente = await _unitOfWork.Clientes.GetByIdAsync(idCliente);
            if (cliente == null)
                throw new KeyNotFoundException("El cliente no existe");

            await _unitOfWork.Clientes.RemoveAsync(idCliente);
        }


        // ----------------- Obtener Cliente por Id -----------------
        public async Task<Cliente> ObtenerPorIdClienteAsync(string idCliente)
        {
            var cliente = await _unitOfWork.Clientes.GetByIdAsync(idCliente);
            if (cliente == null)
                throw new KeyNotFoundException("El cliente no existe");

            return cliente;
        }
    }



}

