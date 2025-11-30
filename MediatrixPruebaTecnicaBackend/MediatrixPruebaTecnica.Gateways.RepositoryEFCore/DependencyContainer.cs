using MediatrixPruebaTecnica.Entities.Interfaces;
using MediatrixPruebaTecnica.Gateways.RepositoryEFCore.DataContext;
using MediatrixPruebaTecnica.Gateways.RepositoryEFCore.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MediatrixPruebaTecnica.Gateways.RepositoryEFCore
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddRepositoriesServices(
            this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("MediatrixPruebaTecnica")));
            services.AddScoped<IEmpleadoRepository, EmpleadoRepository>();
            services.AddScoped<IRegistroPagoRepository, RegistroPagoRepository>();
            services.AddScoped<IRolRepository, RolRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
