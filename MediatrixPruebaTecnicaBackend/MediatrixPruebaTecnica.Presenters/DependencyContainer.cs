using MediatrixPruebaTecnica.Presenters.AuthPresenters;
using MediatrixPruebaTecnica.Presenters.EmpleadoPresenters;
using MediatrixPruebaTecnica.Presenters.RegistroPagoPresenters;
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
using MediatrixPruebaTexnica.UseCasesPorts.RegistroPagoUseCasesPorts.CreateRegistroPago;
using MediatrixPruebaTexnica.UseCasesPorts.RegistroPagoUseCasesPorts.DeleteRegistroPago;
using MediatrixPruebaTexnica.UseCasesPorts.RegistroPagoUseCasesPorts.GetReportePago;
using MediatrixPruebaTexnica.UseCasesPorts.RegistroPagoUseCasesPorts.UpdateRegistroPago;
using Microsoft.Extensions.DependencyInjection;


namespace MediatrixPruebaTecnica.Presenters
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddPresentersServices(
            this IServiceCollection services)
        {
            services.AddScoped<ILoginOutputPort, LoginPresenter>();
            services.AddScoped<ICreateEmpleadoAsalariadoOutputPort, CreateEmpleadoAsalariadoPresenter>();
            services.AddScoped<ICreateEmpleadoAsalariadoPorComisionOutputPort, CreateEmpleadoAsalariadoPorComisionPresenter>();
            services.AddScoped<ICreateEmpleadoPorComisionOutputPort, CreateEmpleadoPorComisionPresenter>();
            services.AddScoped<ICreateEmpleadoPorHorasOutputPort, CreateEmpleadoPorHorasPresenter>();
            services.AddScoped<IDeleteEmpleadoOutputPort, DeleteEmpleadoPresenter>();
            services.AddScoped<IGetAllByFilterEmpleadoOutputPort, GetAllByFilterEmpleadoPresenter>();
            services.AddScoped<IGetAllEmpleadoOutputPort, GetAllEmpleadoPresenter>();
            services.AddScoped<IGetByIdEmpleadoOutputPort, GetByIdEmpleadoPresenter>();
            services.AddScoped<IUpdateEmpleadoAsalariadoOutputPort, UpdateEmpleadoAsalariadoPresenter>();
            services.AddScoped<IUpdateEmpleadoAsalariadoPorComisionOutputPort, UpdateEmpleadoAsalariadoPorComisionPresenter>();
            services.AddScoped<IUpdateEmpleadoPorComisionOutputPort, UpdateEmpleadoPorComisionPresenter>();
            services.AddScoped<IUpdateEmpleadoPorHorasOutputPort, UpdateEmpleadoPorHorasPresenter>();
            services.AddScoped<ICreateRegistroPagoOutputPort, CreateRegistroPagoPresenter>();
            services.AddScoped<IDeleteRegistroPagoOutputPort, DeleteRegistroPagoPresenter>();
            services.AddScoped<IGetReportePagoOutputPort, GetReportePagoPresenter>();
            services.AddScoped<IUpdateRegistroPagoOutputPort, UpdateRegistroPagoPresenter>();

            return services;
        }
    }
}
