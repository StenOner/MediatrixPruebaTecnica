using MediatrixPruebaTexnica.DTOs.RegistroPagoDTOs;
using MediatrixPruebaTexnica.UseCasesPorts.Common;

namespace MediatrixPruebaTexnica.UseCasesPorts.RegistroPagoUseCasesPorts.CreateRegistroPago
{
    public interface ICreateRegistroPagoOutputPort
    {
        Task Handle(Result<RegistroPagoDto> dto);
    }
}
