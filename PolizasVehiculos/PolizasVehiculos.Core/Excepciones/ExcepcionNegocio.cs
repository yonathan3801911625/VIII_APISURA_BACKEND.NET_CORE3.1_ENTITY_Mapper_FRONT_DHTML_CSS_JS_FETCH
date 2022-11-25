using System;
using System.Collections.Generic;
using System.Text;

namespace PolizasVehiculos.Core.Excepciones
{
    public class ExcepcionNegocio : Exception
    {
        public ExcepcionNegocio() {
        
        }

        public ExcepcionNegocio(string mensaje) : base(mensaje)
        {

        }
    }
}
