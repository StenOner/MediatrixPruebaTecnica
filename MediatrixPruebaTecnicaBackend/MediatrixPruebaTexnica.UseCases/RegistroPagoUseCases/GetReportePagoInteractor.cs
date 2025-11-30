using MediatrixPruebaTecnica.Entities.Interfaces;
using MediatrixPruebaTexnica.DTOs.RegistroPagoDTOs;
using MediatrixPruebaTexnica.UseCases.Utility;
using MediatrixPruebaTexnica.UseCasesPorts.Common;
using MediatrixPruebaTexnica.UseCasesPorts.RegistroPagoUseCasesPorts.GetReportePago;

namespace MediatrixPruebaTexnica.UseCases.RegistroPagoUseCases
{
    internal class GetReportePagoInteractor(IRegistroPagoRepository registroPagoRepository, IGetReportePagoOutputPort outputPort, IUnitOfWork unitOfWork)
        : IGetReportePagoInputPort
    {
        private readonly IRegistroPagoRepository _registroPagoRepository = registroPagoRepository;
        private readonly IGetReportePagoOutputPort _outputPort = outputPort;

        public async Task Handle(DateTime inicio, DateTime fin)
        {
            var pagos = await _registroPagoRepository.GetPagosPorPeriodoAsync(inicio, fin);

            var dtos = pagos.Select(RegistroPagoUtility.MapToDto).ToList();

            var reporte = new ReportePagosDto
            {
                FechaInicio = inicio,
                FechaFin = fin,
                Pagos = dtos,
                TotalBruto = dtos.Sum(p => p.MontoBruto),
                TotalDeducciones = dtos.Sum(p => p.Deducciones),
                TotalNeto = dtos.Sum(p => p.MontoNeto)
            };

            await _outputPort.Handle(
                Result<ReportePagosDto>.SuccessResult(reporte)
                );
        }
    }
}
