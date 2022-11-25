using System;
using System.Collections.Generic;
using System.Text;

namespace PolizasVehiculos.Core.DTOs
{
    public class VehiculoDTO
    {
        public int Id { get; set; }
        public string PlacaVehiculo { get; set; }
        public string MarcaVehiculo { get; set; }
        public string VinVehiculo { get; set; }
    }
}
