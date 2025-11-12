using EstructuraVentas.LogicaNegocio.DTOs.Clientes;
using EstructuraVentas.LogicaNegocio.DTOs.Producto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructuraVentas.LogicaNegocio.Validators.Producto
{
    public class CreateProductDtoValidator : AbstractValidator<CreateProductDTO>
    {
        public CreateProductDtoValidator()
        {
            RuleFor(p => p.Nombre)
                .NotEmpty().WithMessage("El nombre del producto es obligatorio.")
                .MaximumLength(100).WithMessage("El nombre del producto no puede exceder los 100 caracteres.");
            RuleFor(p => p.Precio).GreaterThan(0);
        }

    }
}
