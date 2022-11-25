using PolizasVehiculos.Core.Entidades;
using PolizasVehiculos.Core.Interfaces;
using PolizasVehiculos.Infraestructura.Datos;

namespace PolizasVehiculos.Infraestructura.Repositorios
{
    public class PaisRepositorio : /*IPaisRepositorio*/ RepositorioBase<Pais> , IPaisRepositorio
    {
        public PaisRepositorio(DBSegurosContext context) : base(context) {
            
        }

        /* public async Task<IEnumerable<Pais>> ObtenerPaises(){
            var paises = await _context.Pais.ToListAsync();
            return paises;
        }

        public async Task<Pais> ObtenerPais(int id) {
            var pais = await _context.Pais.FirstOrDefaultAsync(x => x.Id == id);
            return pais;
        }

        public async Task InsertarPais(Pais pais) {
            _context.Pais.Add(pais);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ModificarPais(Pais pais) 
        {
            var paisActual = await ObtenerPais(pais.Id);
            paisActual.NombrePais = pais.NombrePais;
            paisActual.SubContiente = pais.SubContiente;

            int filasAfectadas = await _context.SaveChangesAsync();

            return filasAfectadas > 0;
        }

        public async Task<bool> EliminarPais(int id)
        {
            var paisActual = await ObtenerPais(id);

            _context.Pais.Remove(paisActual);

            int filasAfectadas = await _context.SaveChangesAsync();

            return filasAfectadas > 0;
        }*/
    }
}
