using PolizasVehiculos.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PolizasVehiculos.Core.Interfaces
{
    public interface IRepositorio<T> where T : EntidadBase
    {
        Task<T> ObtenerPorId(int id);
        IEnumerable<T> ObtenerTodos();
        Task Agregar(T entidad);
        void Modificar(T entidad);
        Task Eliminar(int id);

    }
}
