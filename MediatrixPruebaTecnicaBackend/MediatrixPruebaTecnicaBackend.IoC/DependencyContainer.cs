using MediatrixPruebaTecnica.Gateways.RepositoryEFCore;
using MediatrixPruebaTecnica.Presenters;
using MediatrixPruebaTexnica.UseCases;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MediatrixPruebaTecnica.IoC
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddMediatrixDependencies(
            this IServiceCollection services, IConfiguration configuration)
        {
            services.AddRepositoriesServices(configuration);
            services.AddUseCasesServices();
            services.AddPresentersServices();

            return services;
        }
    }
}
