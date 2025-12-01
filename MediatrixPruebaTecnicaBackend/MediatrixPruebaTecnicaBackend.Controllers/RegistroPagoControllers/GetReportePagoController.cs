using MediatrixPruebaTexnica.UseCasesPorts.RegistroPagoUseCasesPorts.GetReportePago;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MediatrixPruebaTecnica.Controllers.RegistroPagoControllers
{
    [Route("api/pagos")]
    [ApiController]
    [Authorize]
    public class GetReportePagoController : ControllerBase
    {
        private readonly ILogger<GetReportePagoController> _logger;
        private readonly IGetReportePagoInputPort _inputPort;
        private readonly IGetReportePagoOutputPort _outputPort;

        public GetReportePagoController(
            ILogger<GetReportePagoController> logger,
            IGetReportePagoInputPort inputPort,
            IGetReportePagoOutputPort outputPort)
            => (_logger, _inputPort, _outputPort) = (logger, inputPort, outputPort);

        [HttpGet("reporte")]
        public async Task<IActionResult> Get(
            [FromQuery] DateTime inicio,
            [FromQuery] DateTime fin)
        {
            _logger.LogInformation("Generando reporte de pagos. Inicio={Inicio}, Fin={Fin}", inicio, fin);
            await _inputPort.Handle(inicio, fin);
            _logger.LogInformation("Reporte de pagos generado correctamente. Inicio={Inicio}, Fin={Fin}", inicio, fin);
            return Ok(_outputPort);
        }
    }
}
