using MediatrixPruebaTexnica.DTOs.EmpleadoDTOs;
using MediatrixPruebaTexnica.UseCasesPorts.EmpleadoUseCasesPorts.GetAllByFilterEmpleado;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MediatrixPruebaTecnica.Controllers.EmpleadoControllers
{
    [Route("api/empleados")]
    [ApiController]
    [Authorize]
    public class GetAllByFilterEmpleadoController : ControllerBase
    {
        private readonly ILogger<GetAllByFilterEmpleadoController> _logger;
        private readonly IGetAllByFilterEmpleadoInputPort _inputPort;
        private readonly IGetAllByFilterEmpleadoOutputPort _outputPort;

        public GetAllByFilterEmpleadoController(
            ILogger<GetAllByFilterEmpleadoController> logger,
            IGetAllByFilterEmpleadoInputPort inputPort,
            IGetAllByFilterEmpleadoOutputPort outputPort)
            => (_logger, _inputPort, _outputPort) = (logger, inputPort, outputPort);

        [HttpGet("filtro")]
        public async Task<IActionResult> GetAll([FromQuery] EmpleadoFiltroDto dto)
        {
            _logger.LogInformation("Consultando empleados con filtro. Nombre={Nombre}, Departamento={Departamento}, Activo={Activo}",
                dto.Nombre, dto.Departamento, dto.Activo);

            await _inputPort.Handle(dto);
            _logger.LogInformation("Consulta de empleados con filtro completada.");
            return Ok(_outputPort);
        }
    }
}
