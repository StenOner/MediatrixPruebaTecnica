using MediatrixPruebaTexnica.DTOs.RegistroPagoDTOs;

namespace MediatrixPruebaTexnica.UseCasesPorts.RegistroPagoUseCasesPorts.CreateRegistroPago
{
    public interface ICreateRegistroPagoInputPort
    {
        Task Handle(CreateRegistroPagoDto dto);
    }
}
