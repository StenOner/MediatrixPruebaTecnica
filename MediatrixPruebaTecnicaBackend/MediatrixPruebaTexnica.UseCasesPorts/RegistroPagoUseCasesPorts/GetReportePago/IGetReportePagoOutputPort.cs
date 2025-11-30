using MediatrixPruebaTexnica.DTOs.RegistroPagoDTOs;
using MediatrixPruebaTexnica.UseCasesPorts.Common;

namespace MediatrixPruebaTexnica.UseCasesPorts.RegistroPagoUseCasesPorts.GetReportePago
{
    public interface IGetReportePagoOutputPort
    {
        Task Handle(Result<ReportePagosDto> dto);
    }
}
