using PolizasVehiculos.Core.Entidades;
using PolizasVehiculos.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PolizasVehiculos.Core.Servicios
{
    public class VehiculoServicio : IVehiculoServicio
    {
        private readonly IUnidadDeTrabajo _unidadDeTrabajo;
        //private readonly IRepositorio<Pais> _paisRepositorio;
        public VehiculoServicio(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }
        public async Task<bool> EliminarVehiculo(int id)
        {
            await _unidadDeTrabajo.VehiculoRepositorio.Eliminar(id);
            await _unidadDeTrabajo.SaveChangesAsync();
            return true;
        }

        public async Task InsertarVehiculo(Vehiculo vehiculo)
        {
            await _unidadDeTrabajo.VehiculoRepositorio.Agregar(vehiculo);
            await _unidadDeTrabajo.SaveChangesAsync();
        }

        public async Task<bool> ModificarVehiculo(Vehiculo vehiculo)
        {
            _unidadDeTrabajo.VehiculoRepositorio.Modificar(vehiculo);
            await _unidadDeTrabajo.SaveChangesAsync();
            return true;
        }

        public async Task<Vehiculo> ObtenerVehiculo(int id)
        {
            return await _unidadDeTrabajo.VehiculoRepositorio.ObtenerPorId(id);
        }

        public IEnumerable<Vehiculo> ObtenerVehiculos()
        {
            return _unidadDeTrabajo.VehiculoRepositorio.ObtenerTodos();
        }
    }
}
