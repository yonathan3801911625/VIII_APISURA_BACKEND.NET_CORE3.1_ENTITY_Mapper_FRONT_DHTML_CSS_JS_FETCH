using PolizasVehiculos.Core.Entidades;
using PolizasVehiculos.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PolizasVehiculos.Core.Servicios
{
    public class PaisServicio : IPaisServicio
    {
        private readonly IUnidadDeTrabajo _unidadDeTrabajo;
        //private readonly IRepositorio<Pais> _paisRepositorio;
        public PaisServicio(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        public async Task<bool> EliminarPais(int id)
        {
            await _unidadDeTrabajo.PaisRepositorio.Eliminar(id);
            await _unidadDeTrabajo.SaveChangesAsync();
            return true;
        }

        public async Task InsertarPais(Pais pais)
        {
            await _unidadDeTrabajo.PaisRepositorio.Agregar(pais);
            await _unidadDeTrabajo.SaveChangesAsync();
        }

        public async Task<bool> ModificarPais(Pais pais)
        {
            _unidadDeTrabajo.PaisRepositorio.Modificar(pais);
            await _unidadDeTrabajo.SaveChangesAsync();
            return true;
        }

        public async Task<Pais> ObtenerPais(int id)
        {
            return await _unidadDeTrabajo.PaisRepositorio.ObtenerPorId(id);
        }

        public IEnumerable<Pais> ObtenerPaises()
        {
            return _unidadDeTrabajo.PaisRepositorio.ObtenerTodos();
        }
    }
}
