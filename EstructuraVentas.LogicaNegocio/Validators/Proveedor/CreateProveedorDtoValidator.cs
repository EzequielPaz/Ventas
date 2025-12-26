using EstructuraVentas.LogicaNegocio.DTOs.Producto;
using EstructuraVentas.LogicaNegocio.DTOs.Proveedor;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EstructuraVentas.LogicaNegocio.Validators.Proveedor
{
    public class CreateProveedorDtoValidator :AbstractValidator<CreateProveedorDTO>
    {
        public CreateProveedorDtoValidator()
        {
            RuleFor(p => p.RazonSocial).
               NotEmpty().MaximumLength(50);

            RuleFor(p => p.CodigoProveedor).
               NotEmpty().MaximumLength(50);

            RuleFor(p => p.CUIT)
               .NotEmpty().WithMessage("El CUILT es obligatorio")
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
               .WithMessage("El CUILT debe tener hasta 11 dígitos o el formato con guiones: XX-XXXXXXXX-X. No se permiten letras ni espacios.");


            RuleFor(p => p.Telefono)
                .MaximumLength(30)
                .Matches(@"^\d{1,20}$")
                .WithMessage("El Teléfono debe contener solo números positivos y como máximo 30 dígitos.");


        }
    }
}
