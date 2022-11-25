using PolizasVehiculos.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PolizasVehiculos.Core.Interfaces
{
    public interface IUsuarioServicio
    {
        Task InsertarUsuario(Usuario usuario);

        IEnumerable<Usuario> ObtenerUsuarios();

        Task<Usuario> ObtenerUsuario(int id);

        Task<bool> ModificarUsuario(Usuario usuario);

        Task<bool> EliminarUsuario(int id);

        Task<Usuario> obtenerLogin(Usuario usuario);
    }
}
