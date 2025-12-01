using MediatrixPruebaTexnica.DTOs.RegistroPagoDTOs;
using MediatrixPruebaTexnica.UseCasesPorts.Common;

namespace MediatrixPruebaTexnica.UseCasesPorts.RegistroPagoUseCasesPorts.UpdateRegistroPago
{
    public interface IUpdateRegistroPagoOutputPort
    {
        Task Handle(Result<RegistroPagoDto> dto);
    }
}

