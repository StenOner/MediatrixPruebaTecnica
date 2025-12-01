using MediatrixPruebaTexnica.DTOs.EmpleadoDTOs;
using MediatrixPruebaTexnica.UseCasesPorts.EmpleadoUseCasesPorts.UpdateEmpleadoAsalariadoPorComision;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MediatrixPruebaTecnica.Controllers.EmpleadoControllers
{
    [Route("api/empleados")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class UpdateEmpleadoAsalariadoPorComisionController : ControllerBase
    {
        private readonly ILogger<UpdateEmpleadoAsalariadoPorComisionController> _logger;
        private readonly IUpdateEmpleadoAsalariadoPorComisionInputPort _inputPort;
        private readonly IUpdateEmpleadoAsalariadoPorComisionOutputPort _outputPort;

        public UpdateEmpleadoAsalariadoPorComisionController(
            ILogger<UpdateEmpleadoAsalariadoPorComisionController> logger,
            IUpdateEmpleadoAsalariadoPorComisionInputPort inputPort,
            IUpdateEmpleadoAsalariadoPorComisionOutputPort outputPort)
            => (_logger, _inputPort, _outputPort) = (logger, inputPort, outputPort);

        [HttpPut("asalariados-por-comision/{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateEmpleadoAsalariadoPorComisionDto dto)
        {
            _logger.LogInformation(
                "Iniciando actualización de empleado asalariado por comisión. Id={Id}, Nombre={PrimerNombre} {ApellidoPaterno}, Departamento={Departamento}, SalarioBase={SalarioBase}, VentasBrutas={VentasBrutas}, TarifaComision={TarifaComision}, Activo={Activo}",
                id, dto.PrimerNombre, dto.ApellidoPaterno, dto.Departamento, dto.SalarioBase, dto.VentasBrutas, dto.TarifaComision, dto.Activo);

            await _inputPort.Handle(id, dto);
            return Ok(_outputPort);
        }
    }
}
