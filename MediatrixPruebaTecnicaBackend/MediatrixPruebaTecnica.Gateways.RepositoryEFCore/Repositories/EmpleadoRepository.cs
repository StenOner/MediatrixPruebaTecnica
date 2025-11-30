using MediatrixPruebaTecnica.Entities.Bases;
using MediatrixPruebaTecnica.Entities.Interfaces;
using MediatrixPruebaTecnica.Gateways.RepositoryEFCore.DataContext;
using Microsoft.EntityFrameworkCore;

namespace MediatrixPruebaTecnica.Gateways.RepositoryEFCore.Repositories
{
    public class EmpleadoRepository : Repository<Empleado>, IEmpleadoRepository
    {
        public EmpleadoRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Empleado>> GetEmpleadosActivosAsync()
        {
            return await _dbSet
                .Where(e => e.Activo)
                .OrderBy(e => e.ApellidoPaterno)
                .ToListAsync();
        }

        public async Task<IEnumerable<Empleado>> GetEmpleadosPorDepartamentoAsync(string departamento)
        {
            return await _dbSet
                .Where(e => e.Departamento == departamento && e.Activo)
                .OrderBy(e => e.ApellidoPaterno)
                .ToListAsync();
        }

        public async Task<Empleado?> GetEmpleadoConPagosAsync(Guid id)
        {
            return await _dbSet
                .Include(e => e.RegistrosPagos)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<bool> ExisteNumeroSeguroSocialAsync(string numeroSeguroSocial, Guid? empleadoId = null)
        {
            var query = _dbSet.Where(e => e.NumeroSeguroSocial == numeroSeguroSocial);

            if (empleadoId.HasValue)
                query = query.Where(e => e.Id != empleadoId.Value);

            return await query.AnyAsync();
        }

        public async Task<IEnumerable<Empleado>> BuscarEmpleadosAsync(string? nombre, string? departamento, bool? activo)
        {
            var query = _dbSet.AsQueryable();

            if (!string.IsNullOrWhiteSpace(nombre))
            {
                query = query.Where(e =>
                    e.PrimerNombre.Contains(nombre) ||
                    e.ApellidoPaterno.Contains(nombre));
            }

            if (!string.IsNullOrWhiteSpace(departamento))
            {
                query = query.Where(e => e.Departamento == departamento);
            }

            if (activo.HasValue)
            {
                query = query.Where(e => e.Activo == activo.Value);
            }

            return await query
                .OrderBy(e => e.ApellidoPaterno)
                .ThenBy(e => e.PrimerNombre)
                .ToListAsync();
        }
    }
}
