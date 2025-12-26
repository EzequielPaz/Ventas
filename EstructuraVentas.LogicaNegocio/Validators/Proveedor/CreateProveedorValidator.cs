using EstructuraVentas.LogicaNegocio.DTOs.Proveedor;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructuraVentas.LogicaNegocio.Validators.Proveedor
{
    public class CreateProveedorValidator : AbstractValidator<CreateProveedorDto>
    {
        public CreateProveedorValidator()
        {
            RuleFor(x => x.RazonSocial).NotEmpty().WithMessage("La razón social es obligatoria.");
            RuleFor(x => x.CUIT).NotEmpty().WithMessage("El CUIT es obligatorio.");
            RuleFor(x => x.CodigoProveedor).NotEmpty().WithMessage("El código es obligatorio.");
        }
    }
}
