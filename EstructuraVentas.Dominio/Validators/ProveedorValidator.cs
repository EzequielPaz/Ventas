using EstructuraVentas.Dominio.Modelos;
using FluentValidation;


namespace EstructuraVentas.Dominio.Validators
{
    public class ProveedorValidator:AbstractValidator<Proveedor>
    {
        public ProveedorValidator()
        {
            RuleFor(p => p.RazonSocial).MaximumLength(50)
                .WithMessage("La cantidad maxima de caracteres es de 50");
            
            RuleFor(p => p.CUIT).Matches(@"^\d{2}-\d{8}-\d{1}$")
                .WithMessage("El CUIT debe tener un formato numerico de XX-XXXXXXXX-X.");

            RuleFor(p => p.CodigoProovedor).MaximumLength(50)
                .WithMessage("La cantidad maxima de caracteres es de 50");

            RuleFor(p => p.Telefono)
                .MaximumLength(20)
                .Matches(@"^\d{1,20}$")
                .WithMessage("El Teléfono debe contener solo números positivos y como máximo 20 dígitos.");


            RuleFor(p => p.Correo).NotEmpty().EmailAddress().MaximumLength(50)
               .WithMessage("Debe digitar un correo con formato valido");
            
        }

    }
}
