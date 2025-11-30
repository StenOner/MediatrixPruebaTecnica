using MediatrixPruebaTexnica.UseCasesPorts.RegistroPagoUseCasesPorts.GetReportePago;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MediatrixPruebaTecnica.Controllers.RegistroPagoControllers
{
    [Route("api/pagos")]
    [ApiController]
    [Authorize]
    public class GetReportePagoController : ControllerBase
    {
        private readonly IGetReportePagoInputPort _inputPort;
        private readonly IGetReportePagoOutputPort _outputPort;

        public GetReportePagoController(IGetReportePagoInputPort inputPort, IGetReportePagoOutputPort outputPort)
            => (_inputPort, _outputPort) = (inputPort, outputPort);

        [HttpGet("reporte")]
        public async Task<IActionResult> Get(
            [FromQuery] DateTime inicio,
            [FromQuery] DateTime fin)
        {
            await _inputPort.Handle(inicio, fin);
            return Ok(_outputPort);
        }
    }
}
