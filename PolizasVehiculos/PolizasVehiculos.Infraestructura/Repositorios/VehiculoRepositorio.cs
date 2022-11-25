using PolizasVehiculos.Core.Entidades;
using PolizasVehiculos.Core.Interfaces;
using PolizasVehiculos.Infraestructura.Datos;
using System;
using System.Collections.Generic;
using System.Text;

namespace PolizasVehiculos.Infraestructura.Repositorios
{
    public class VehiculoRepositorio : RepositorioBase<Vehiculo>, IVehiculoRepositorio
    {
        public VehiculoRepositorio(DBSegurosContext contexto) : base(contexto) { }
    }
}
