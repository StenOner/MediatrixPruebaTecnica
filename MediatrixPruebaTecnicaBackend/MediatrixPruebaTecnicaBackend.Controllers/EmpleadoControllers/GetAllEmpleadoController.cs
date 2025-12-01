using MediatrixPruebaTexnica.UseCasesPorts.EmpleadoUseCasesPorts.GetAllEmpleado;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MediatrixPruebaTecnica.Controllers.EmpleadoControllers
{
    [Route("api/empleados")]
    [ApiController]
    [Authorize]
    public class GetAllEmpleadoController : ControllerBase
    {
        private readonly ILogger<GetAllEmpleadoController> _logger;
        private readonly IGetAllEmpleadoInputPort _inputPort;
        private readonly IGetAllEmpleadoOutputPort _outputPort;

        public GetAllEmpleadoController(
            ILogger<GetAllEmpleadoController> logger,
            IGetAllEmpleadoInputPort inputPort,
            IGetAllEmpleadoOutputPort outputPort)
            => (_logger, _inputPort, _outputPort) = (logger, inputPort, outputPort);

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation("Iniciando consulta de todos los empleados.");
            await _inputPort.Handle();
            _logger.LogInformation("Consulta completada de todos los empleados.");
            return Ok(_outputPort);
        }
    }
}
