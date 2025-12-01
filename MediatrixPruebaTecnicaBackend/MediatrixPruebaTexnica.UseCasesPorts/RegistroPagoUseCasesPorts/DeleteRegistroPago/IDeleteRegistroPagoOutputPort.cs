using MediatrixPruebaTexnica.UseCasesPorts.Common;

namespace MediatrixPruebaTexnica.UseCasesPorts.RegistroPagoUseCasesPorts.DeleteRegistroPago
{
    public interface IDeleteRegistroPagoOutputPort
    {
        Task Handle(Result<bool> dto);
    }
}
