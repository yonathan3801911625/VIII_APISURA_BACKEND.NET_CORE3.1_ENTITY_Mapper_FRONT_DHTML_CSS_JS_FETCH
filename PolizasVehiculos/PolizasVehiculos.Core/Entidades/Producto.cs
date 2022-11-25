using System;
using System.Collections.Generic;

namespace PolizasVehiculos.Core.Entidades
{
    public partial class Producto : EntidadBase
    {
        public Producto()
        {
            ProductoPais = new HashSet<ProductoPais>();
            ProductoPoliza = new HashSet<ProductoPoliza>();
        }

        //public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public string TipoProducto { get; set; }

        public virtual ICollection<ProductoPais> ProductoPais { get; set; }
        public virtual ICollection<ProductoPoliza> ProductoPoliza { get; set; }
    }
}
