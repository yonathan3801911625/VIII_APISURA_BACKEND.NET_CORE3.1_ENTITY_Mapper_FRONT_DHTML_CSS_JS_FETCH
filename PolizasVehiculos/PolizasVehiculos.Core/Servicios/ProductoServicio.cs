using PolizasVehiculos.Core.Entidades;
using PolizasVehiculos.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PolizasVehiculos.Core.Servicios
{
    public class ProductoServicio : IProductoServicio
    {
        private readonly IUnidadDeTrabajo _unidadDeTrabajo;
        //private readonly IRepositorio<Pais> _paisRepositorio;
        public ProductoServicio(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        public async Task<bool> EliminarProducto(int id)
        {
            await _unidadDeTrabajo.ProductoRepositorio.Eliminar(id);
            await _unidadDeTrabajo.SaveChangesAsync();
            return true;
        }

        public async Task InsertarProducto(Producto producto)
        {
            await _unidadDeTrabajo.ProductoRepositorio.Agregar(producto);
            await _unidadDeTrabajo.SaveChangesAsync();
        }

        public async Task<bool> ModificarProducto(Producto producto)
        {
            _unidadDeTrabajo.ProductoRepositorio.Modificar(producto);
            await _unidadDeTrabajo.SaveChangesAsync();
            return true;
        }

        public async Task<Producto> ObtenerProducto(int id)
        {
            return await _unidadDeTrabajo.ProductoRepositorio.ObtenerPorId(id);
        }

        public IEnumerable<Producto> ObtenerProductos()
        {
            return _unidadDeTrabajo.ProductoRepositorio.ObtenerTodos();
        }
    }
}
