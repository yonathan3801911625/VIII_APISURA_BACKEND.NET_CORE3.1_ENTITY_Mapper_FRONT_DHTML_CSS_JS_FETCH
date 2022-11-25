using PolizasVehiculos.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PolizasVehiculos.Core.Interfaces
{
    public interface IPolizaServicio
    {
        Task InsertarPoliza(Poliza poliza);

        IEnumerable<Poliza> ObtenerPolizas();

        Task<Poliza> ObtenerPoliza(int id);

        Task<bool> ModificarPoliza(Poliza poliza);

        Task<bool> EliminarPoliza(int id);
    }
}
