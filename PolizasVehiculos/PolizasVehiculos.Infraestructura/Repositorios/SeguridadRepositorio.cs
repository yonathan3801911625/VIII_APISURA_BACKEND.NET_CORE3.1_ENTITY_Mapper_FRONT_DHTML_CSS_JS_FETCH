using Microsoft.EntityFrameworkCore;
using PolizasVehiculos.Core.Entidades;
using PolizasVehiculos.Core.Interfaces;
using PolizasVehiculos.Infraestructura.Datos;
using System.Threading.Tasks;

namespace PolizasVehiculos.Infraestructura.Repositorios
{
    public class SeguridadRepositorio : RepositorioBase<Seguridad>, ISeguridadRepositorio
    {
        public SeguridadRepositorio(DBSegurosContext contexto) : base(contexto) { }

        public async Task<Seguridad> obtenerLoginParaCredenciales(UsuarioLogin usuarioLogin)
        {
            return await _entidades.FirstOrDefaultAsync(x => x.Usuario == usuarioLogin.usuario && x.Contrasena == usuarioLogin.contraseña);
        }
    }
}
