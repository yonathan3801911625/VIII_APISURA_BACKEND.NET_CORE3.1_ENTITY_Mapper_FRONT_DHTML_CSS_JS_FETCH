using Microsoft.EntityFrameworkCore;
using PolizasVehiculos.Core.Entidades;
using PolizasVehiculos.Core.Interfaces;
using PolizasVehiculos.Infraestructura.Datos;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolizasVehiculos.Infraestructura.Repositorios
{
    public class RepositorioBase<T> : IRepositorio<T> where T : EntidadBase
    {
        protected readonly DBSegurosContext _contexto;
        protected DbSet<T> _entidades;
        public RepositorioBase(DBSegurosContext contexto) {
            _contexto = contexto;
            _entidades = contexto.Set<T>();
        }
        public async Task Agregar(T entidad)
        {
            await _entidades.AddAsync(entidad);
        }

        public async Task Eliminar(int id)
        {
            T entidad = await ObtenerPorId(id);
            _entidades.Remove(entidad);
        }

        public void Modificar(T entidad)
        {
            _entidades.Update(entidad);
        }

        public async Task<T> ObtenerPorId(int id)
        {
            return await _entidades.FindAsync(id);
        }

        public IEnumerable<T> ObtenerTodos()
        {
            return _entidades.AsEnumerable();
        }
    }
}
