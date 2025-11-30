using MediatrixPruebaTexnica.UseCasesPorts.Common;
using MediatrixPruebaTexnica.UseCasesPorts.RegistroPagoUseCasesPorts.DeleteRegistroPago;

namespace MediatrixPruebaTecnica.Presenters.RegistroPagoPresenters
{
    public class DeleteRegistroPagoPresenter : IDeleteRegistroPagoOutputPort, IPresenter<Result<bool>>
    {
        public Result<bool> Content { get; private set; } = new();

        public Task Handle(Result<bool> content)
        {
            Content = content;
            return Task.CompletedTask;
        }
    }
}
