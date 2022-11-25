using FluentValidation;
using PolizasVehiculos.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace PolizasVehiculos.Infraestructura.Validadores
{
    public class PaisValidador : AbstractValidator<PaisDTO>
    {
        public PaisValidador() 
        {
            RuleFor(pais => pais.IdPais).NotNull();

            RuleFor(pais => pais.NombrePais).NotNull().Length(5,50);

            RuleFor(pais => pais.SubContiente).NotNull().Length(5,50);
        }
    }
}
