using MediatrixPruebaTexnica.DTOs.EmpleadoDTOs;
using MediatrixPruebaTexnica.UseCasesPorts.Common;
using MediatrixPruebaTexnica.UseCasesPorts.EmpleadoUseCasesPorts.GetAllEmpleado;

namespace MediatrixPruebaTecnica.Presenters.EmpleadoPresenters
{
    public class GetAllEmpleadoPresenter : IGetAllEmpleadoOutputPort, IPresenter<Result<IEnumerable<EmpleadoDto>>>
    {
        public Result<IEnumerable<EmpleadoDto>> Content { get; private set; } = new();

        public Task Handle(Result<IEnumerable<EmpleadoDto>> content)
        {
            Content = content;
            return Task.CompletedTask;
        }
    }
}
