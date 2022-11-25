using System;
using System.Collections.Generic;
using System.Text;

namespace PolizasVehiculos.Core.DTOs
{
    public class PolizaDTO
    {
        public int Id { get; set; }
        public DateTime FechaVigenciaPoliza { get; set; }
        public int IdVehiculoUsuario { get; set; }
        public ICollection<ProductoPolizaDTO> ProductoPoliza { get; set; }
    }
}
