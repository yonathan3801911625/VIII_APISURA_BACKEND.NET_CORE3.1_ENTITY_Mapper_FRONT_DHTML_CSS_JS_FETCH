using Microsoft.EntityFrameworkCore;
using PolizasVehiculos.Core.Entidades;
using PolizasVehiculos.Core.Interfaces;
using PolizasVehiculos.Infraestructura.Datos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PolizasVehiculos.Infraestructura.Repositorios
{
    public class UsuarioRepositorio : RepositorioBase<Usuario>, IUsuarioRepositorio
    {
        public UsuarioRepositorio(DBSegurosContext contexto) : base(contexto) { }

        public async Task<Usuario> obtnerLogin(Usuario usuario)
        {
            return await _entidades.FirstOrDefaultAsync(x => x.LoginUsuario == usuario.LoginUsuario && x.PasswordUsuario == usuario.PasswordUsuario);
        }
    }
}
