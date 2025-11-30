using MediatrixPruebaTecnica.Entities.Interfaces;
using MediatrixPruebaTecnica.Entities.POCOs;
using MediatrixPruebaTecnica.Gateways.RepositoryEFCore.DataContext;
using Microsoft.EntityFrameworkCore;

namespace MediatrixPruebaTecnica.Gateways.RepositoryEFCore.Repositories
{
    public class RegistroPagoRepository : Repository<RegistroPago>, IRegistroPagoRepository
    {
        public RegistroPagoRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task<IEnumerable<RegistroPago>> GetPagosPorEmpleadoAsync(Guid empleadoId)
        {
            return await _dbSet
                .Where(r => r.EmpleadoId == empleadoId)
                .OrderByDescending(r => r.FechaPago)
                .ToListAsync();
        }

        public async Task<IEnumerable<RegistroPago>> GetPagosPorPeriodoAsync(DateTime inicio, DateTime fin)
        {
            return await _dbSet
                .Include(r => r.Empleado)
                .Where(r => r.FechaPago >= inicio && r.FechaPago <= fin)
                .OrderBy(r => r.FechaPago)
                .ToListAsync();
        }

        public async Task<RegistroPago?> GetUltimoPagoEmpleadoAsync(Guid empleadoId)
        {
            return await _dbSet
                .Where(r => r.EmpleadoId == empleadoId)
                .OrderByDescending(r => r.FechaPago)
                .FirstOrDefaultAsync();
        }
    }
}
