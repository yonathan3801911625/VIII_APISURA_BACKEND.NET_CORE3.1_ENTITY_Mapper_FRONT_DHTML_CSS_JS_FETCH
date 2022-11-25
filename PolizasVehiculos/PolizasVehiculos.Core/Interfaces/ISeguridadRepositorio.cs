using PolizasVehiculos.Core.Entidades;
using System.Threading.Tasks;

namespace PolizasVehiculos.Core.Interfaces
{
    public interface ISeguridadRepositorio : IRepositorio<Seguridad>
    {
        Task<Seguridad> obtenerLoginParaCredenciales(UsuarioLogin usuarioLogin);
    }
}