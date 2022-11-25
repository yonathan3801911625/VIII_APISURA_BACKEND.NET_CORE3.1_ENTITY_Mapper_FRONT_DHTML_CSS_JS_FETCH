using PolizasVehiculos.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PolizasVehiculos.Core.Interfaces
{
    public interface IVehiculoServicio
    {
        Task InsertarVehiculo(Vehiculo vehiculo);

        IEnumerable<Vehiculo> ObtenerVehiculos();

        Task<Vehiculo> ObtenerVehiculo(int id);

        Task<bool> ModificarVehiculo(Vehiculo vehiculo);

        Task<bool> EliminarVehiculo(int id);
    }
}
