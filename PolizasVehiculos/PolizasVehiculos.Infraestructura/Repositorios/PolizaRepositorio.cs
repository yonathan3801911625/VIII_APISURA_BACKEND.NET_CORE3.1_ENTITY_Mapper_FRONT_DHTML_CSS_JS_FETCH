using PolizasVehiculos.Core.Entidades;
using PolizasVehiculos.Core.Interfaces;
using PolizasVehiculos.Infraestructura.Datos;
using System;
using System.Collections.Generic;
using System.Text;

namespace PolizasVehiculos.Infraestructura.Repositorios
{
    public class PolizaRepositorio : RepositorioBase<Poliza>, IPolizaRepositorio
    {
        public PolizaRepositorio(DBSegurosContext contexto) : base(contexto) { }
    }
}
