using MediatrixPruebaTexnica.DTOs.RegistroPagoDTOs;
using MediatrixPruebaTexnica.UseCasesPorts.Common;
using MediatrixPruebaTexnica.UseCasesPorts.RegistroPagoUseCasesPorts.CreateRegistroPago;

namespace MediatrixPruebaTecnica.Presenters.RegistroPagoPresenters
{
    public class CreateRegistroPagoPresenter : ICreateRegistroPagoOutputPort, IPresenter<Result<RegistroPagoDto>>
    {
        public Result<RegistroPagoDto> Content { get; private set; } = new();

        public Task Handle(Result<RegistroPagoDto> content)
        {
            Content = content;
            return Task.CompletedTask;
        }
    }
}
