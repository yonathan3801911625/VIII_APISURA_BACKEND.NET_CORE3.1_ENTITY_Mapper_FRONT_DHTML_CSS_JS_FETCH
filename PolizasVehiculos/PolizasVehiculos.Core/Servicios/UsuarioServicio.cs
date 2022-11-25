using PolizasVehiculos.Core.Entidades;
using PolizasVehiculos.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PolizasVehiculos.Core.Servicios
{
    public class UsuarioServicio : IUsuarioServicio
    {
        private readonly IUnidadDeTrabajo _unidadDeTrabajo;
        public UsuarioServicio(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        public async Task<bool> EliminarUsuario(int id)
        {
            await _unidadDeTrabajo.UsuarioRepositorio.Eliminar(id);
            await _unidadDeTrabajo.SaveChangesAsync();
            return true;
        }

        public async Task InsertarUsuario(Usuario usuario)
        {
            await _unidadDeTrabajo.UsuarioRepositorio.Agregar(usuario);
            await _unidadDeTrabajo.SaveChangesAsync();
        }

        public async Task<bool> ModificarUsuario(Usuario usuario)
        {
            _unidadDeTrabajo.UsuarioRepositorio.Modificar(usuario);
            await _unidadDeTrabajo.SaveChangesAsync();
            return true;
        }

        public async Task<Usuario> ObtenerUsuario(int id)
        {
            return await _unidadDeTrabajo.UsuarioRepositorio.ObtenerPorId(id);
        }

        public IEnumerable<Usuario> ObtenerUsuarios()
        {
            return _unidadDeTrabajo.UsuarioRepositorio.ObtenerTodos();
        }

        public async Task<Usuario> obtenerLogin(Usuario usuario)
        {
            return await _unidadDeTrabajo.UsuarioRepositorio.obtnerLogin(usuario);
        }
    }
}
