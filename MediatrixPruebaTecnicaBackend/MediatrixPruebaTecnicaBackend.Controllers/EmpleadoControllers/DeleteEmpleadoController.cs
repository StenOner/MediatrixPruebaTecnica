using MediatrixPruebaTexnica.UseCasesPorts.EmpleadoUseCasesPorts.DeleteEmpleado;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MediatrixPruebaTecnica.Controllers.EmpleadoControllers
{
    [Route("api/empleados")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class DeleteEmpleadoController : ControllerBase
    {
        private readonly ILogger<DeleteEmpleadoController> _logger;
        private readonly IDeleteEmpleadoInputPort _inputPort;
        private readonly IDeleteEmpleadoOutputPort _outputPort;

        public DeleteEmpleadoController(
            ILogger<DeleteEmpleadoController> logger,
            IDeleteEmpleadoInputPort inputPort,
            IDeleteEmpleadoOutputPort outputPort)
            => (_logger, _inputPort, _outputPort) = (logger, inputPort, outputPort);

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            _logger.LogInformation("Iniciando eliminación de empleado. Id={Id}", id);
            await _inputPort.Handle(id);
            _logger.LogInformation("Eliminación completada para empleado Id={Id}", id);
            return Ok(_outputPort);
        }
    }
}
