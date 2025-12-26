using EstructuraVentas.LogicaNegocio.DTOs.Producto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructuraVentas.LogicaNegocio.Validators.Producto
{
    public class UpdateProducDtoValidator : AbstractValidator<UpdateProductDTO>
    {
        public UpdateProducDtoValidator()
        {
            RuleFor(p => p.IdProducto)
                .NotEmpty().WithMessage("El ID del producto es obligatorio.")
                .Length(24).WithMessage("El ID del producto debe tener 24 caracteres (ObjectId de MongoDB).");

            RuleFor(p => p.Nombre)
                .NotEmpty().WithMessage("El nombre del producto es obligatorio.")
                .MaximumLength(100).WithMessage("El nombre no puede superar los 100 caracteres.");

            RuleFor(p => p.Descripcion)
                .MaximumLength(255)
                .WithMessage("La descripción no puede superar los 255 caracteres.");

            RuleFor(p => p.Codigo)
                .NotEmpty().WithMessage("El código del producto es obligatorio.")
                .MaximumLength(50).WithMessage("El código no puede superar los 50 caracteres.");

            RuleFor(p => p.Stock)
                .GreaterThanOrEqualTo(0)
                .WithMessage("El stock no puede ser negativo.");

            RuleFor(p => p.Marca)
                .MaximumLength(100)
                .WithMessage("La marca no puede superar los 100 caracteres.");

            RuleFor(p => p.Precio)
                .GreaterThan(0)
                .WithMessage("El precio debe ser mayor que 0.");

            RuleFor(p => p.CategoriaId)
                .NotEmpty()
                .WithMessage("Debe seleccionarse una categoría válida.");

        }
    }
}
