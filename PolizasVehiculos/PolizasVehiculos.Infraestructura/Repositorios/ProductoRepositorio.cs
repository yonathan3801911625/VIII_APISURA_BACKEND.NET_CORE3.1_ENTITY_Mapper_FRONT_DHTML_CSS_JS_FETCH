using PolizasVehiculos.Core.Entidades;
using PolizasVehiculos.Core.Interfaces;
using PolizasVehiculos.Infraestructura.Datos;
using System;
using System.Collections.Generic;
using System.Text;

namespace PolizasVehiculos.Infraestructura.Repositorios
{
    public class ProductoRepositorio : RepositorioBase<Producto>, IProductoRepositorio
    {
        public ProductoRepositorio(DBSegurosContext contexto) : base(contexto) { }


    }
}
