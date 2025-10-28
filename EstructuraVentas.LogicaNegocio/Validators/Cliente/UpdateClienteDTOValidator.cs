using EstructuraVentas.LogicaNegocio.DTOs.Clientes;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EstructuraVentas.LogicaNegocio.Validators.Cliente
{
    public class UpdateClienteDTOValidator : AbstractValidator<UpdateClienteDTO>
    {
        public UpdateClienteDTOValidator()
        {
            RuleFor(c => c.IDClientes)
               .GreaterThan(0).WithMessage("El Id debe ser válido");

            RuleFor(c => c.NombreCliente)
                .NotEmpty().WithMessage("El nombre es obligatorio")
                .Length(3, 50).WithMessage("El nombre debe tener entre 3 y 50 caracteres.");

            RuleFor(c => c.Email)
                .EmailAddress().WithMessage("Debe digitar un correo con formato válido")
                .MaximumLength(50).WithMessage("El correo no puede superar los 50 caracteres.")
                .When(x => !string.IsNullOrEmpty(x.Email));

            RuleFor(p => p.Documento)
                .NotEmpty().WithMessage("El documento es obligatorio")
                .Must(c =>
                {
                    if (c.Contains("-"))
                    {
                        // Si hay guiones, validar formato exacto XX-XXXXXXXX-X
                        return Regex.IsMatch(c, @"^\d{2}-\d{8}-\d{1}$");
                    }
                    else
                    {
                        // Solo números y máximo 11 dígitos
                        return c.All(char.IsDigit) && c.Length <= 11;
                    }
                })
                .WithMessage("El documento debe tener hasta 11 dígitos o el formato con guiones: XX-XXXXXXXX-X. No se permiten letras ni espacios.");

            RuleFor(p => p.Celular)
                .Matches(@"^\d{1,30}$")
                .WithMessage("El Teléfono debe contener solo números positivos y como máximo 30 dígitos.")
                .When(p => !string.IsNullOrEmpty(p.Celular));


        }
    }
}
