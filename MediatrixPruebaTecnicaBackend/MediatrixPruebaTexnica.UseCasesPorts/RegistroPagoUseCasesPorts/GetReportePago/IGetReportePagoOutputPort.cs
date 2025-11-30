using MediatrixPruebaTexnica.DTOs.RegistroPagoDTOs;
using MediatrixPruebaTexnica.UseCasesPorts.Common;

namespace MediatrixPruebaTexnica.UseCasesPorts.RegistroPagoUseCasesPorts.GetReportePago
{
    public interface IGetReportePagoOutputPort
    {
        Task<Result<ReportePagosDto>> Handle(ReportePagosDto dto);
    }
}
