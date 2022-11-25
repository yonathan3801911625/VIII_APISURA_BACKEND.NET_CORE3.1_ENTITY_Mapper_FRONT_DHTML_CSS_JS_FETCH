using System;
using System.Collections.Generic;

namespace PolizasVehiculos.Core.Entidades
{
    public partial class VehiculoUsuario : EntidadBase
    {
        public VehiculoUsuario()
        {
            Poliza = new HashSet<Poliza>();
        }

        //public int IdVehiculoUsuario { get; set; }
        public int IdVehiculo { get; set; }
        public int IdUsuario { get; set; }

        public virtual Usuario Usuario { get; set; }
        public virtual Vehiculo Vehiculo { get; set; }
        public virtual ICollection<Poliza> Poliza { get; set; }
    }
}
