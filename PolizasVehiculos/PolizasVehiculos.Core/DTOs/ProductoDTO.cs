using System;
using System.Collections.Generic;
using System.Text;

namespace PolizasVehiculos.Core.DTOs
{
    public class ProductoDTO 
    {
        public int Id { get; set; }
        public string NombreProducto { get; set; }
        public string TipoProducto { get; set; }

        public ICollection<ProductoPaisDTO> ProductoPais { get; set; }
    }
}
