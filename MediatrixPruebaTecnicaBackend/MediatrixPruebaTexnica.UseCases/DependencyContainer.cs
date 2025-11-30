using MediatrixPruebaTexnica.UseCases.AuthUseCases;
using MediatrixPruebaTexnica.UseCases.EmpleadoUseCases;
using MediatrixPruebaTexnica.UseCasesPorts.AuthUseCasesPorts.Login;
using MediatrixPruebaTexnica.UseCasesPorts.EmpleadoUseCasesPorts.GetAllEmpleado;
using MediatrixPruebaTexnica.UseCasesPorts.EmpleadoUseCasesPorts.GetByIdEmpleado;
using Microsoft.Extensions.DependencyInjection;

namespace MediatrixPruebaTexnica.UseCases
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddUseCasesServices(
            this IServiceCollection services)
        {
            services.AddTransient<ILoginInputPort, LoginInteractor>();
            services.AddTransient<IGetAllEmpleadoInputPort, GetAllEmpleadoInteractor>();
            services.AddTransient<IGetByIdEmpleadoInputPort, GetByIdEmpleadoInteractor>();

            return services;
        }
    }
}
