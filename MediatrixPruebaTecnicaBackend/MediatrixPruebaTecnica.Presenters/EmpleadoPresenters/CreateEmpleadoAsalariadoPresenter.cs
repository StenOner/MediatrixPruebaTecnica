using MediatrixPruebaTexnica.DTOs.EmpleadoDTOs;
using MediatrixPruebaTexnica.UseCasesPorts.Common;
using MediatrixPruebaTexnica.UseCasesPorts.EmpleadoUseCasesPorts.CreateEmpleadoAsalariado;

namespace MediatrixPruebaTecnica.Presenters.EmpleadoPresenters
{
    public class CreateEmpleadoAsalariadoPresenter : ICreateEmpleadoAsalariadoOutputPort, IPresenter<Result<EmpleadoDto>>
    {
        public Result<EmpleadoDto> Content { get; private set; } = new();

        public Task Handle(Result<EmpleadoDto> content)
        {
            Content = content;
            return Task.CompletedTask;
        }
    }
}
