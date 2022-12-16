
using Autoestrada.Domain.Entity.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autoestrada.Domain.Entity.Validations
{
    public class ProveedorValidator : AbstractValidator<Proveedor>
    {
        public ProveedorValidator()
        {
            RuleFor(x => x.Codigo).NotNull().NotEmpty().
                WithMessage("El Codigo NO puede ser nulo ni vacio");

            RuleFor(x => x.Descripcion).NotNull().NotEmpty().
                WithMessage("La descripción NO puede ser nula ni vacia");

            RuleFor(x => x.Telefono).
                Matches(@"^(\d){10}$").
                WithMessage("El celular o telefono debe tener 10 números");


        }
    }
}
