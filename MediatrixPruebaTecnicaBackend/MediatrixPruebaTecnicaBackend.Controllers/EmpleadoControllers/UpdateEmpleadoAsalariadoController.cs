using MediatrixPruebaTexnica.DTOs.EmpleadoDTOs;
using MediatrixPruebaTexnica.UseCasesPorts.EmpleadoUseCasesPorts.UpdateEmpleadoAsalariado;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MediatrixPruebaTecnica.Controllers.EmpleadoControllers
{
    [Route("api/empleados")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class UpdateEmpleadoAsalariadoController : ControllerBase
    {
        private readonly ILogger<UpdateEmpleadoAsalariadoController> _logger;
        private readonly IUpdateEmpleadoAsalariadoInputPort _inputPort;
        private readonly IUpdateEmpleadoAsalariadoOutputPort _outputPort;

        public UpdateEmpleadoAsalariadoController(
            ILogger<UpdateEmpleadoAsalariadoController> logger,
            IUpdateEmpleadoAsalariadoInputPort inputPort,
            IUpdateEmpleadoAsalariadoOutputPort outputPort)
            => (_logger, _inputPort, _outputPort) = (logger, inputPort, outputPort);

        [HttpPut("asalariados/{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateEmpleadoAsalariadoDto dto)
        {
            _logger.LogInformation(
                "Iniciando actualización de empleado asalariado. Id={Id}, Nombre={PrimerNombre} {ApellidoPaterno}, Departamento={Departamento}, SalarioSemanal={SalarioSemanal}, Activo={Activo}",
                id, dto.PrimerNombre, dto.ApellidoPaterno, dto.Departamento, dto.SalarioSemanal, dto.Activo);

            await _inputPort.Handle(id, dto);
            return Ok(_outputPort);
        }
    }
}
