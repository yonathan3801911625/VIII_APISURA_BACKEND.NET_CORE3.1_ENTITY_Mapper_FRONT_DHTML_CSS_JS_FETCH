using System;
using System.Collections.Generic;

namespace PolizasVehiculos.Core.Entidades
{
    public partial class Poliza : EntidadBase
    {
        public Poliza()
        {
            ProductoPoliza = new HashSet<ProductoPoliza>();
        }

        //public int IdPoliza { get; set; }
        public DateTime FechaVigenciaPoliza { get; set; }
        public int IdVehiculoUsuario { get; set; }

        public virtual VehiculoUsuario VehiculoUsuario { get; set; }
        public virtual ICollection<ProductoPoliza> ProductoPoliza { get; set; }
    }
}
