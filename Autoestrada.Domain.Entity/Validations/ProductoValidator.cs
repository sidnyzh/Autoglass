
using Autoestrada.Domain.Entity.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autoestrada.Domain.Entity.Validations
{
    public class ProductoValidator : AbstractValidator<Producto>
    {
        public ProductoValidator()
        {
            RuleFor(x => x.Id).NotNull().NotEmpty().
                WithMessage("El Id NO puede ser nulo ni vacio");

            RuleFor(x => x.Descripcion).NotNull().NotEmpty().
                WithMessage("La descripción NO puede ser nula ni vacia");

            RuleFor(x => x.Estado).Matches(@"^(activo)|(inactivo)$").
                WithMessage("El estado sólo puede contener activo o inactivo");

            RuleFor(x => x.FechaFabricacion).LessThan(x => x.FechaVencimiento).
                WithMessage("La fecha de fabricación no puede ser mayor o igual que la fecha de vencimiento");
        }
    }
}
