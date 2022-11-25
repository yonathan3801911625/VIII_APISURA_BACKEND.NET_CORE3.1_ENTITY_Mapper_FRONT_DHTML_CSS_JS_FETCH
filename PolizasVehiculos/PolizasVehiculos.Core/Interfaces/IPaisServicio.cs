using PolizasVehiculos.Core.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PolizasVehiculos.Core.Interfaces
{
    public interface IPaisServicio
    {
        Task InsertarPais(Pais pais);

        IEnumerable<Pais> ObtenerPaises();

        Task<Pais> ObtenerPais(int id);

        Task<bool> ModificarPais(Pais pais);

        Task<bool> EliminarPais(int id);
    }
}