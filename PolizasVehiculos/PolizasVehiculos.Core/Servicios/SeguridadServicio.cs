using PolizasVehiculos.Core.Entidades;
using PolizasVehiculos.Core.Interfaces;
using System.Threading.Tasks;

namespace PolizasVehiculos.Core.Servicios
{
    public class SeguridadServicio : ISeguridadServicio
    {
        private readonly IUnidadDeTrabajo _unidadDeTrabajo;
        public SeguridadServicio(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        public async Task<Seguridad> obtenerLoginParaCredenciales(UsuarioLogin usuarioLogin)
        {
            return await _unidadDeTrabajo.SeguridadRepositorio.obtenerLoginParaCredenciales(usuarioLogin);
        }

        public async Task registrarUsuario(Seguridad seguridad)
        {
            await _unidadDeTrabajo.SeguridadRepositorio.Agregar(seguridad);
            await _unidadDeTrabajo.SaveChangesAsync();
        }
    }
}
