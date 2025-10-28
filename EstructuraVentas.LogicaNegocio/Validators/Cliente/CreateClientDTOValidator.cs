using EstructuraVentas.Dominio;
using EstructuraVentas.LogicaNegocio.DTOs.Clientes;
using FluentValidation;
using System.Text.RegularExpressions;

namespace EstructuraVentas.LogicaNegocio.Validators.Cliente
{
    public class CreateClientDTOValidator : AbstractValidator<CreateClienteDTO>
    {
        public CreateClientDTOValidator()
        {
            RuleFor(c => c.NombreCliente).NotEmpty().MaximumLength(30);

            RuleFor(c => c.Email).NotEmpty().EmailAddress().MaximumLength(50)
               .WithMessage("Debe digitar un correo con formato valido");

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
                .MaximumLength(30)
                .Matches(@"^\d{1,20}$")
                .WithMessage("El Teléfono debe contener solo números positivos y como máximo 30 dígitos.");

        }
    }
}
