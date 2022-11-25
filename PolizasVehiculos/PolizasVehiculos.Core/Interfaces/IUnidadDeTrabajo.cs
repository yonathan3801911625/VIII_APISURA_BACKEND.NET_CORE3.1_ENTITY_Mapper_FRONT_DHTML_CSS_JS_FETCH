using PolizasVehiculos.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PolizasVehiculos.Core.Interfaces
{
    public interface IUnidadDeTrabajo :IDisposable
    {
        IRepositorio<Pais> PaisRepositorio { get; }

        ISeguridadRepositorio SeguridadRepositorio { get; }

        IProductoRepositorio ProductoRepositorio { get; }

        IVehiculoRepositorio VehiculoRepositorio { get; }

        IUsuarioRepositorio UsuarioRepositorio { get; }

        IPolizaRepositorio PolizaRepositorio { get; }

        void SaveChanges();

        Task SaveChangesAsync();
    }
}
