using MediatrixPruebaTecnica.Presenters.AuthPresenters;
using MediatrixPruebaTecnica.Presenters.EmpleadoPresenters;
using MediatrixPruebaTexnica.UseCasesPorts.AuthUseCasesPorts.Login;
using MediatrixPruebaTexnica.UseCasesPorts.EmpleadoUseCasesPorts.GetAllEmpleado;
using MediatrixPruebaTexnica.UseCasesPorts.EmpleadoUseCasesPorts.GetByIdEmpleado;
using Microsoft.Extensions.DependencyInjection;


namespace MediatrixPruebaTecnica.Presenters
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddPresentersServices(
            this IServiceCollection services)
        {
            services.AddScoped<ILoginOutputPort, LoginPresenter>();
            services.AddScoped<IGetAllEmpleadoOutputPort, GetAllEmpleadoPresenter>();
            services.AddScoped<IGetByIdEmpleadoOutputPort, GetByIdEmpleadoPresenter>();

            return services;
        }
    }
}
