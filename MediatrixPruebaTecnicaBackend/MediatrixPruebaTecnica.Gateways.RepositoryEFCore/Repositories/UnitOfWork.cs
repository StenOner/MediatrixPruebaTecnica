using MediatrixPruebaTecnica.Entities.Interfaces;
using MediatrixPruebaTecnica.Gateways.RepositoryEFCore.DataContext;

namespace MediatrixPruebaTecnica.Gateways.RepositoryEFCore.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;

        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task BeginTransactionAsync()
        {
            await _context.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            await _context.CommitTransactionAsync();
        }

        public async Task RollbackTransactionAsync()
        {
            await _context.RollbackTransactionAsync();
        }

        public void Dispose() => _context.Dispose();
    }
}
