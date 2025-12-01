using MediatrixPruebaTecnica.Entities.Bases;
using MediatrixPruebaTecnica.Entities.POCOs;
using MediatrixPruebaTecnica.Gateways.RepositoryEFCore.DataContext.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace MediatrixPruebaTecnica.Gateways.RepositoryEFCore.DataContext
{
    public class ApplicationContext(DbContextOptions<ApplicationContext> options) : DbContext(options)
    {
        private IDbContextTransaction? _currentTransaction;

        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<EmpleadoAsalariado> EmpleadosAsalariados { get; set; }
        public DbSet<EmpleadoPorHoras> EmpleadosPorHoras { get; set; }
        public DbSet<EmpleadoPorComision> EmpleadosPorComision { get; set; }
        public DbSet<EmpleadoAsalariadoPorComision> EmpleadosAsalariadosPorComision { get; set; }
        public DbSet<RegistroPago> RegistrosPagos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new EmpleadoConfiguration());
            modelBuilder.ApplyConfiguration(new RegistroPagoConfiguration());
            modelBuilder.ApplyConfiguration(new RolConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    if (entry.Property("FechaCreacion").CurrentValue == null)
                        entry.Property("FechaCreacion").CurrentValue = DateTime.UtcNow;
                }

                if (entry.State == EntityState.Modified)
                {
                    var propertyNames = entry.Properties.Select(p => p.Metadata.Name).ToList();

                    if (propertyNames.Contains("FechaModificacion"))
                        entry.Property("FechaModificacion").CurrentValue = DateTime.UtcNow;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        public async Task BeginTransactionAsync()
        {
            if (_currentTransaction != null)
                return;

            _currentTransaction = await Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            try
            {
                await SaveChangesAsync();
                _currentTransaction?.Commit();
            }
            catch
            {
                await RollbackTransactionAsync();
                throw;
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }

        public async Task RollbackTransactionAsync()
        {
            try
            {
                _currentTransaction?.Rollback();
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }
    }
}


