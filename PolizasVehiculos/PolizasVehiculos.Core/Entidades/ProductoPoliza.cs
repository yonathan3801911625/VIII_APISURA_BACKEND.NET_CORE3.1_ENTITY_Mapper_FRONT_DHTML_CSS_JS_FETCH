using System;
using System.Collections.Generic;

namespace PolizasVehiculos.Core.Entidades
{
    public partial class ProductoPoliza : EntidadBase
    {
        //public int IdProductoPoliza { get; set; }
        public int IdProducto { get; set; }
        public int IdPoliza { get; set; }

        public virtual Poliza Poliza { get; set; }
        public virtual Producto Producto { get; set; }
    }
}
