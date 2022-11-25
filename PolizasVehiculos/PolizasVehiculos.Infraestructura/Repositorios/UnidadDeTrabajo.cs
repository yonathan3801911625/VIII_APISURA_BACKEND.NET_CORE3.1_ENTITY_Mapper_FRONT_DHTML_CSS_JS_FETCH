using PolizasVehiculos.Core.Entidades;
using PolizasVehiculos.Core.Interfaces;
using PolizasVehiculos.Infraestructura.Datos;
using System.Threading.Tasks;

namespace PolizasVehiculos.Infraestructura.Repositorios
{
    public class UnidadDeTrabajo : IUnidadDeTrabajo
    {
        private readonly DBSegurosContext _contexto;
        private readonly IRepositorio<Pais> _paisRepositorio;
        private readonly ISeguridadRepositorio _seguridadRepositorio;
        private readonly IProductoRepositorio _productoRepositorio;
        private readonly IVehiculoRepositorio _vehiculoRepositorio;
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly IPolizaRepositorio _polizaRepositorio;

        public UnidadDeTrabajo(DBSegurosContext contexto)
        {
            _contexto = contexto;
        }

        public IRepositorio<Pais> PaisRepositorio => _paisRepositorio ?? new RepositorioBase<Pais>(_contexto);

        public ISeguridadRepositorio SeguridadRepositorio => _seguridadRepositorio ?? new SeguridadRepositorio(_contexto);

        public IProductoRepositorio ProductoRepositorio => _productoRepositorio ?? new ProductoRepositorio(_contexto);

        public IVehiculoRepositorio VehiculoRepositorio => _vehiculoRepositorio ?? new VehiculoRepositorio(_contexto);

        public IUsuarioRepositorio UsuarioRepositorio => _usuarioRepositorio ?? new UsuarioRepositorio(_contexto);

        public IPolizaRepositorio PolizaRepositorio => _polizaRepositorio ?? new PolizaRepositorio(_contexto);

        public void Dispose()
        {
            if (_contexto != null) 
            {
                _contexto.Dispose();
            }
        }

        public void SaveChanges()
        {
            _contexto.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _contexto.SaveChangesAsync();
        }
    }
}
