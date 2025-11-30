using MediatrixPruebaTexnica.DTOs.RegistroPagoDTOs;
using MediatrixPruebaTexnica.UseCasesPorts.Common;
using MediatrixPruebaTexnica.UseCasesPorts.RegistroPagoUseCasesPorts.GetReportePago;

namespace MediatrixPruebaTecnica.Presenters.RegistroPagoPresenters
{
    public class GetReportePagoPresenter : IGetReportePagoOutputPort, IPresenter<Result<ReportePagosDto>>
    {
        public Result<ReportePagosDto> Content { get; private set; } = new();

        public Task Handle(Result<ReportePagosDto> content)
        {
            Content = content;
            return Task.CompletedTask;
        }
    }
}
