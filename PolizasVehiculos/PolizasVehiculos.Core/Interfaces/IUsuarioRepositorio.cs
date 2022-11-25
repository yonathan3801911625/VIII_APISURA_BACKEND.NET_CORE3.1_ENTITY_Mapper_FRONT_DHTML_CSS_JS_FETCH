using PolizasVehiculos.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PolizasVehiculos.Core.Interfaces
{
    public interface IUsuarioRepositorio : IRepositorio<Usuario>
    {
        Task<Usuario> obtnerLogin(Usuario usuario);
    }
}
