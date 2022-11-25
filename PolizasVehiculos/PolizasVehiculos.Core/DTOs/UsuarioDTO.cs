using System;
using System.Collections.Generic;
using System.Text;

namespace PolizasVehiculos.Core.DTOs
{
    public class UsuarioDTO
    {
        public int Id { get; set; }

        public string NumIdentificacionUsuario { get; set; }
        public string TipoDocUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string ApellidosUsuario { get; set; }
        public string LoginUsuario { get; set; }
        public string PasswordUsuario { get; set; }

        public ICollection<VehiculoUsuarioDTO> VehiculoUsuario { get; set; }
    }
}
