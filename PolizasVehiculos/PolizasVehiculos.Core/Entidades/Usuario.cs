using System;
using System.Collections.Generic;

namespace PolizasVehiculos.Core.Entidades
{
    public partial class Usuario : EntidadBase
    {
        public Usuario()
        {
            VehiculoUsuario = new HashSet<VehiculoUsuario>();
        }

        //public int IdUsuario { get; set; }
        public string NumIdentificacionUsuario { get; set; }
        public string TipoDocUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string ApellidosUsuario { get; set; }
        public string LoginUsuario { get; set; }
        public string PasswordUsuario { get; set; }

        public virtual ICollection<VehiculoUsuario> VehiculoUsuario { get; set; }
    }
}
