using PolizasVehiculos.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PolizasVehiculos.Core.Interfaces
{
    public interface IProductoServicio
    {
        Task InsertarProducto(Producto producto);

        IEnumerable<Producto> ObtenerProductos();

        Task<Producto> ObtenerProducto(int id);

        Task<bool> ModificarProducto(Producto producto);

        Task<bool> EliminarProducto(int id);
    }
}
