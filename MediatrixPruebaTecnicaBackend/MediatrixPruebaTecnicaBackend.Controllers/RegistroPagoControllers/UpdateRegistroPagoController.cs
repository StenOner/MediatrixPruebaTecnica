using MediatrixPruebaTexnica.DTOs.RegistroPagoDTOs;
using MediatrixPruebaTexnica.UseCasesPorts.RegistroPagoUseCasesPorts.UpdateRegistroPago;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MediatrixPruebaTecnica.Controllers.RegistroPagoControllers
{
    [Route("api/pagos")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class UpdateRegistroPagoController : ControllerBase
    {
        private readonly ILogger<UpdateRegistroPagoController> _logger;
        private readonly IUpdateRegistroPagoInputPort _inputPort;
        private readonly IUpdateRegistroPagoOutputPort _outputPort;

        public UpdateRegistroPagoController(
            ILogger<UpdateRegistroPagoController> logger,
            IUpdateRegistroPagoInputPort inputPort,
            IUpdateRegistroPagoOutputPort outputPort)
            => (_logger, _inputPort, _outputPort) = (logger, inputPort, outputPort);

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateRegistroPagoDto dto)
        {
            _logger.LogInformation("Iniciando actualización de registro de pago. Id={Id}, Deducciones={Deducciones}, ObservacionesPresentes={HasObservaciones}",
                id, dto.Deducciones, !string.IsNullOrWhiteSpace(dto.Observaciones));

            await _inputPort.Handle(id, dto);
            _logger.LogInformation("Actualización completada para registro de pago Id={Id}", id);
            return Ok(_outputPort);
        }
    }
}
