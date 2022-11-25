using System;
using System.Collections.Generic;

namespace PolizasVehiculos.Core.Entidades
{
    public partial class Vehiculo : EntidadBase
    {
        public Vehiculo()
        {
            VehiculoUsuario = new HashSet<VehiculoUsuario>();
        }

        //public int IdVehiculo { get; set; }
        public string PlacaVehiculo { get; set; }
        public string MarcaVehiculo { get; set; }
        public string VinVehiculo { get; set; }

        public virtual ICollection<VehiculoUsuario> VehiculoUsuario { get; set; }
    }
}
