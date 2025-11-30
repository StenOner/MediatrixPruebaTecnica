using MediatrixPruebaTexnica.UseCasesPorts.Common;
using MediatrixPruebaTexnica.UseCasesPorts.EmpleadoUseCasesPorts.DeleteEmpleado;

namespace MediatrixPruebaTecnica.Presenters.EmpleadoPresenters
{
    public class DeleteEmpleadoPresenter : IDeleteEmpleadoOutputPort, IPresenter<Result<bool>>
    {
        public Result<bool> Content { get; private set; } = new();

        public Task Handle(Result<bool> content)
        {
            Content = content;
            return Task.CompletedTask;
        }
    }
}
