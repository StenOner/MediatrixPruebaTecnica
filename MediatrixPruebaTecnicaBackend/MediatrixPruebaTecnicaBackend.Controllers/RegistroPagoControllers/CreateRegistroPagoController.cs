using MediatrixPruebaTexnica.DTOs.RegistroPagoDTOs;
using MediatrixPruebaTexnica.UseCasesPorts.RegistroPagoUseCasesPorts.CreateRegistroPago;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MediatrixPruebaTecnica.Controllers.RegistroPagoControllers
{
    [Route("api/pagos")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class CreateRegistroPagoController : ControllerBase
    {
        private readonly ILogger<CreateRegistroPagoController> _logger;
        private readonly ICreateRegistroPagoInputPort _inputPort;
        private readonly ICreateRegistroPagoOutputPort _outputPort;

        public CreateRegistroPagoController(
            ILogger<CreateRegistroPagoController> logger,
            ICreateRegistroPagoInputPort inputPort,
            ICreateRegistroPagoOutputPort outputPort)
            => (_logger, _inputPort, _outputPort) = (logger, inputPort, outputPort);

        [HttpPost]
        public async Task<IActionResult> Create(CreateRegistroPagoDto dto)
        {
            _logger.LogInformation("Iniciando creación de registro de pago. EmpleadoId={EmpleadoId}, PeriodoInicio={PeriodoInicio}, PeriodoFin={PeriodoFin}, Deducciones={Deducciones}",
                dto.EmpleadoId, dto.PeriodoInicio, dto.PeriodoFin, dto.Deducciones);

            await _inputPort.Handle(dto);
            _logger.LogInformation("Creación completada de registro de pago para EmpleadoId={EmpleadoId}", dto.EmpleadoId);
            return Ok(_outputPort);
        }
    }
}
