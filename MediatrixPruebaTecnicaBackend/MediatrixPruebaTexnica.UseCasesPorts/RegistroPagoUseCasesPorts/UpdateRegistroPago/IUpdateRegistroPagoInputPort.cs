using MediatrixPruebaTexnica.DTOs.RegistroPagoDTOs;

namespace MediatrixPruebaTexnica.UseCasesPorts.RegistroPagoUseCasesPorts.UpdateRegistroPago
{
    public interface IUpdateRegistroPagoInputPort
    {
        Task Handle(Guid id, UpdateRegistroPagoDto dto);
    }
}
