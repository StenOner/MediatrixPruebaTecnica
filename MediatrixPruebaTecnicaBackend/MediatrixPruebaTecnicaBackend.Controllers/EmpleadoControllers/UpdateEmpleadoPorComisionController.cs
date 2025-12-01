using MediatrixPruebaTexnica.DTOs.EmpleadoDTOs;
using MediatrixPruebaTexnica.UseCasesPorts.EmpleadoUseCasesPorts.UpdateEmpleadoPorComision;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MediatrixPruebaTecnica.Controllers.EmpleadoControllers
{
    [Route("api/empleados")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class UpdateEmpleadoPorComisionController : ControllerBase
    {
        private readonly ILogger<UpdateEmpleadoPorComisionController> _logger;
        private readonly IUpdateEmpleadoPorComisionInputPort _inputPort;
        private readonly IUpdateEmpleadoPorComisionOutputPort _outputPort;

        public UpdateEmpleadoPorComisionController(
            ILogger<UpdateEmpleadoPorComisionController> logger,
            IUpdateEmpleadoPorComisionInputPort inputPort,
            IUpdateEmpleadoPorComisionOutputPort outputPort)
            => (_logger, _inputPort, _outputPort) = (logger, inputPort, outputPort);

        [HttpPut("por-comision/{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateEmpleadoPorComisionDto dto)
        {
            _logger.LogInformation(
                "Iniciando actualización de empleado por comisión. Id={Id}, Nombre={PrimerNombre} {ApellidoPaterno}, Departamento={Departamento}, VentasBrutas={VentasBrutas}, TarifaComision={TarifaComision}, Activo={Activo}",
                id, dto.PrimerNombre, dto.ApellidoPaterno, dto.Departamento, dto.VentasBrutas, dto.TarifaComision, dto.Activo);

            await _inputPort.Handle(id, dto);
            return Ok(_outputPort);
        }
    }
}
