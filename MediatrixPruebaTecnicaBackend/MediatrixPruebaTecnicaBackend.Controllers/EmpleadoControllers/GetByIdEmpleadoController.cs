using MediatrixPruebaTexnica.UseCasesPorts.EmpleadoUseCasesPorts.GetByIdEmpleado;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MediatrixPruebaTecnica.Controllers.EmpleadoControllers
{
    [Route("api/empleados")]
    [ApiController]
    [Authorize]
    public class GetByIdEmpleadoController : ControllerBase
    {
        private readonly ILogger<GetByIdEmpleadoController> _logger;
        private readonly IGetByIdEmpleadoInputPort _inputPort;
        private readonly IGetByIdEmpleadoOutputPort _outputPort;

        public GetByIdEmpleadoController(
            ILogger<GetByIdEmpleadoController> logger,
            IGetByIdEmpleadoInputPort inputPort,
            IGetByIdEmpleadoOutputPort outputPort)
            => (_logger, _inputPort, _outputPort) = (logger, inputPort, outputPort);

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            _logger.LogInformation("Iniciando consulta de empleado. Id={Id}", id);
            await _inputPort.Handle(id);
            _logger.LogInformation("Consulta completada para empleado Id={Id}", id);
            return Ok(_outputPort);
        }
    }
}
