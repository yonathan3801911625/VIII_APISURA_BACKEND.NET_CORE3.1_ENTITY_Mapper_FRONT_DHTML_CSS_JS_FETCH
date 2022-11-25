using PolizasVehiculos.Core.Enumeradores;
using System;
using System.Collections.Generic;
using System.Text;

namespace PolizasVehiculos.Core.Entidades
{
    public class Seguridad : EntidadBase
    {
        public string Usuario { get; set; }

        public string NombreUsuario { get; set; }

        public string Contrasena { get; set; }

        public TiposRoles Rol { get; set; }
    }
}
