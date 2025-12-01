using MediatrixPruebaTecnica.Entities.Interfaces;
using MediatrixPruebaTecnica.Entities.POCOs;
using MediatrixPruebaTecnica.Gateways.RepositoryEFCore.DataContext;
using Microsoft.EntityFrameworkCore;

namespace MediatrixPruebaTecnica.Gateways.RepositoryEFCore.Repositories
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task<Usuario?> GetByNombreUsuarioAsync(string nombreUsuario)
        {
            return await _dbSet
                .Include(u => u.Rol)
                .FirstOrDefaultAsync(u => u.NombreUsuario == nombreUsuario);
        }

        public async Task<Usuario?> GetUsuarioConRolAsync(Guid id)
        {
            return await _dbSet
                .Include(u => u.Rol)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<bool> ExisteNombreUsuarioAsync(string nombreUsuario, Guid? usuarioId = null)
        {
            var query = _dbSet.Where(u => u.NombreUsuario == nombreUsuario);

            if (usuarioId.HasValue)
                query = query.Where(u => u.Id != usuarioId.Value);

            return await query.AnyAsync();
        }
    }
}
