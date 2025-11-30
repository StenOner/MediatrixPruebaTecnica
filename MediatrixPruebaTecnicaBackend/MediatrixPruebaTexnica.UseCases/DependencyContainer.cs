using MediatrixPruebaTexnica.UseCases.AuthUseCases;
using MediatrixPruebaTexnica.UseCases.EmpleadoUseCases;
using MediatrixPruebaTexnica.UseCasesPorts.AuthUseCasesPorts.Login;
using MediatrixPruebaTexnica.UseCasesPorts.EmpleadoUseCasesPorts.CreateEmpleadoAsalariado;
using MediatrixPruebaTexnica.UseCasesPorts.EmpleadoUseCasesPorts.CreateEmpleadoAsalariadoPorComision;
using MediatrixPruebaTexnica.UseCasesPorts.EmpleadoUseCasesPorts.CreateEmpleadoPorComision;
using MediatrixPruebaTexnica.UseCasesPorts.EmpleadoUseCasesPorts.CreateEmpleadoPorHoras;
using MediatrixPruebaTexnica.UseCasesPorts.EmpleadoUseCasesPorts.DeleteEmpleado;
using MediatrixPruebaTexnica.UseCasesPorts.EmpleadoUseCasesPorts.GetAllByFilterEmpleado;
using MediatrixPruebaTexnica.UseCasesPorts.EmpleadoUseCasesPorts.GetAllEmpleado;
using MediatrixPruebaTexnica.UseCasesPorts.EmpleadoUseCasesPorts.GetByIdEmpleado;
using MediatrixPruebaTexnica.UseCasesPorts.EmpleadoUseCasesPorts.UpdateEmpleadoAsalariado;
using MediatrixPruebaTexnica.UseCasesPorts.EmpleadoUseCasesPorts.UpdateEmpleadoAsalariadoPorComision;
using MediatrixPruebaTexnica.UseCasesPorts.EmpleadoUseCasesPorts.UpdateEmpleadoPorComision;
using MediatrixPruebaTexnica.UseCasesPorts.EmpleadoUseCasesPorts.UpdateEmpleadoPorHoras;
using Microsoft.Extensions.DependencyInjection;

namespace MediatrixPruebaTexnica.UseCases
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddUseCasesServices(
            this IServiceCollection services)
        {
            services.AddTransient<ILoginInputPort, LoginInteractor>();
            services.AddTransient<ICreateEmpleadoAsalariadoInputPort, CreateEmpleadoAsalariadoInteractor>();
            services.AddTransient<ICreateEmpleadoAsalariadoPorComisionInputPort, CreateEmpleadoAsalariadoPorComisionInteractor>();
            services.AddTransient<ICreateEmpleadoPorComisionInputPort, CreateEmpleadoPorComisionInteractor>();
            services.AddTransient<ICreateEmpleadoPorHorasInputPort, CreateEmpleadoPorHorasInteractor>();
            services.AddTransient<IDeleteEmpleadoInputPort, DeleteEmpleadoInteractor>();
            services.AddTransient<IGetAllByFilterEmpleadoInputPort, GetAllByFilterEmpleadoInteractor>();
            services.AddTransient<IGetAllEmpleadoInputPort, GetAllEmpleadoInteractor>();
            services.AddTransient<IGetByIdEmpleadoInputPort, GetByIdEmpleadoInteractor>();
            services.AddTransient<IUpdateEmpleadoAsalariadoInputPort, UpdateEmpleadoAsalariadoInteractor>();
            services.AddTransient<IUpdateEmpleadoAsalariadoPorComisionInputPort, UpdateEmpleadoAsalariadoPorComisionPorComisionInteractor>();
            services.AddTransient<IUpdateEmpleadoPorComisionInputPort, UpdateEmpleadoPorComisionInteractor>();
            services.AddTransient<IUpdateEmpleadoPorHorasInputPort, UpdateEmpleadoPorHorasInteractor>();

            return services;
        }
    }
}
