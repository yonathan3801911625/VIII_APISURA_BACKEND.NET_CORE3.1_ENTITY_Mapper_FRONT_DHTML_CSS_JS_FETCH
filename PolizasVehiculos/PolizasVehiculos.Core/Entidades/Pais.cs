using System;
using System.Collections.Generic;

namespace PolizasVehiculos.Core.Entidades
{
    public partial class Pais : EntidadBase
    {
        public Pais()
        {
            ProductoPais = new HashSet<ProductoPais>();
        }

        //public int IdPais { get; set; }
        public string NombrePais { get; set; }
        public string SubContiente { get; set; }

        public virtual ICollection<ProductoPais> ProductoPais { get; set; }
    }
}
