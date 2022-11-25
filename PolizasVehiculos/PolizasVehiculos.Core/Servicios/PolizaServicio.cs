using PolizasVehiculos.Core.Entidades;
using PolizasVehiculos.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PolizasVehiculos.Core.Servicios
{
    public class PolizaServicio : IPolizaServicio
    {
        private readonly IUnidadDeTrabajo _unidadDeTrabajo;
        public PolizaServicio(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        public async Task<bool> EliminarPoliza(int id)
        {
            await _unidadDeTrabajo.PolizaRepositorio.Eliminar(id);
            await _unidadDeTrabajo.SaveChangesAsync();
            return true;
        }

        public async Task InsertarPoliza(Poliza poliza)
        {
            await _unidadDeTrabajo.PolizaRepositorio.Agregar(poliza);
            await _unidadDeTrabajo.SaveChangesAsync();
        }

        public async Task<bool> ModificarPoliza(Poliza poliza)
        {
            _unidadDeTrabajo.PolizaRepositorio.Modificar(poliza);
            await _unidadDeTrabajo.SaveChangesAsync();
            return true;
        }

        public async Task<Poliza> ObtenerPoliza(int id)
        {
            return await _unidadDeTrabajo.PolizaRepositorio.ObtenerPorId(id);
        }

        public IEnumerable<Poliza> ObtenerPolizas()
        {
            return _unidadDeTrabajo.PolizaRepositorio.ObtenerTodos();
        }
    }
}
