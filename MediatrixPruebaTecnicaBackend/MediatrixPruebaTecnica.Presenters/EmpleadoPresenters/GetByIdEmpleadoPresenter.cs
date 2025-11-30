using MediatrixPruebaTexnica.DTOs.EmpleadoDTOs;
using MediatrixPruebaTexnica.UseCasesPorts.Common;
using MediatrixPruebaTexnica.UseCasesPorts.EmpleadoUseCasesPorts.GetByIdEmpleado;

namespace MediatrixPruebaTecnica.Presenters.EmpleadoPresenters
{
    public class GetByIdEmpleadoPresenter : IGetByIdEmpleadoOutputPort, IPresenter<Result<EmpleadoDto>>
    {
        public Result<EmpleadoDto> Content { get; private set; } = new();

        public Task Handle(Result<EmpleadoDto> response)
        {
            Content = response;
            return Task.CompletedTask;
        }
    }
}
