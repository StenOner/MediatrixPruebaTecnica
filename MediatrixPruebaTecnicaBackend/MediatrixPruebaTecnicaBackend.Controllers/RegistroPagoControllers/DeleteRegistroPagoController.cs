using MediatrixPruebaTexnica.UseCasesPorts.RegistroPagoUseCasesPorts.DeleteRegistroPago;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MediatrixPruebaTecnica.Controllers.RegistroPagoControllers
{
    [Route("api/pagos")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class DeleteRegistroPagoController : ControllerBase
    {
        private readonly ILogger<DeleteRegistroPagoController> _logger;
        private readonly IDeleteRegistroPagoInputPort _inputPort;
        private readonly IDeleteRegistroPagoOutputPort _outputPort;

        public DeleteRegistroPagoController(
            ILogger<DeleteRegistroPagoController> logger,
            IDeleteRegistroPagoInputPort inputPort,
            IDeleteRegistroPagoOutputPort outputPort)
            => (_logger, _inputPort, _outputPort) = (logger, inputPort, outputPort);

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            _logger.LogInformation("Iniciando eliminación de registro de pago. Id={Id}", id);
            await _inputPort.Handle(id);
            _logger.LogInformation("Eliminación completada para registro de pago Id={Id}", id);
            return Ok(_outputPort);
        }
    }
}
