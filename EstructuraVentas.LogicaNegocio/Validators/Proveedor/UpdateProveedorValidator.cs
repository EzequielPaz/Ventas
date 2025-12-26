using EstructuraVentas.LogicaNegocio.DTOs.Proveedor;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructuraVentas.LogicaNegocio.Validators.Proveedor
{
    public class UpdateProveedorValidator:AbstractValidator<UpdateProveedorDto>
    {
        public UpdateProveedorValidator()
        {
            RuleFor(x => x.IdProveedor).GreaterThan(0);
            RuleFor(x => x.RazonSocial).NotEmpty();
            RuleFor(x => x.CUIT).NotEmpty();
            RuleFor(x => x.CodigoProveedor).NotEmpty();

        }
    }
}
