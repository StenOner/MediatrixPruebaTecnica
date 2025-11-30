using MediatrixPruebaTexnica.DTOs.RegistroPagoDTOs;

namespace MediatrixPruebaTexnica.UseCasesPorts.RegistroPagoUseCasesPorts.GetReportePago
{
    public interface IGetReportePagoInputPort
    {
        Task Handle(ReportePagosDto dto);
    }
}
