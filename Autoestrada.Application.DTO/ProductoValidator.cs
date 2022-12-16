using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autoestrada.Application.DTO
{
    public class ProductoDTOValidator : AbstractValidator<ProductoDTO>
    {
        public ProductoDTOValidator()
        {

            RuleFor(x => x.Descripcion).NotNull().NotEmpty().
                WithMessage("La descripción NO puede ser nula ni vacia");

            RuleFor(x => x.FechaFabricacion).LessThan(x => x.FechaVencimiento).
                WithMessage("La fecha de fabricación no puede ser mayor o igual que la fecha de vencimiento");
        }
    }
}
