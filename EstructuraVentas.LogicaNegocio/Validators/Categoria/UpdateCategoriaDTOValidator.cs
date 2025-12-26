using EstructuraVentas.LogicaNegocio.DTOs.Categoria;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructuraVentas.LogicaNegocio.Validators.Categoria
{
    public class UpdateCategoriaDTOValidator:AbstractValidator<UpdateCategoriaDTO>
    {
        public UpdateCategoriaDTOValidator()
        {
            RuleFor(x => x.IdCategoria)
                .NotEmpty().WithMessage("El Id de la categoría es obligatorio.")
                .Length(24).WithMessage("El Id de la categoría debe tener 24 caracteres (ObjectId de Mongo).");

            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre de la categoría es obligatorio.")
                .MaximumLength(100).WithMessage("El nombre no puede superar los 100 caracteres.");

            RuleFor(x => x.Descripcion)
                .MaximumLength(250).WithMessage("La descripción no puede superar los 250 caracteres.");

        }
    }
}
