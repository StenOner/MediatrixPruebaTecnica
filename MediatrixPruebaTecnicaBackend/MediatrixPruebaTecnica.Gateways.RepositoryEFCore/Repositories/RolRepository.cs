using MediatrixPruebaTecnica.Entities.Interfaces;
using MediatrixPruebaTecnica.Entities.POCOs;
using MediatrixPruebaTecnica.Gateways.RepositoryEFCore.DataContext;
using Microsoft.EntityFrameworkCore;

namespace MediatrixPruebaTecnica.Gateways.RepositoryEFCore.Repositories
{
    public class RolRepository : Repository<Rol>, IRolRepository
    {
        public RolRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task<Rol?> GetByNombreAsync(string nombre)
        {
            return await _dbSet
                .FirstOrDefaultAsync(r => r.Nombre == nombre);
        }
    }
}
