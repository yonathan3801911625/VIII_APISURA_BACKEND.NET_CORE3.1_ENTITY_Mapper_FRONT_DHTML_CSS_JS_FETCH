using System;
using System.Collections.Generic;

namespace PolizasVehiculos.Core.Entidades
{
    public partial class ProductoPais : EntidadBase
    {
        //public int IdProductoPais { get; set; }
        public int IdPais { get; set; }
        public int IdProducto { get; set; }

        public virtual Pais Pais { get; set; }
        public virtual Producto Producto { get; set; }
    }
}
