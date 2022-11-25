using PolizasVehiculos.Core.Entidades;
using System.Threading.Tasks;

namespace PolizasVehiculos.Core.Interfaces
{
    public interface ISeguridadServicio
    {
        Task<Seguridad> obtenerLoginParaCredenciales(UsuarioLogin usuarioLogin);
        Task registrarUsuario(Seguridad seguridad);
    }
}