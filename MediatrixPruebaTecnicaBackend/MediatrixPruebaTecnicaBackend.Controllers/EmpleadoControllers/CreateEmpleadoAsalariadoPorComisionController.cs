using MediatrixPruebaTexnica.DTOs.EmpleadoDTOs;
using MediatrixPruebaTexnica.UseCasesPorts.EmpleadoUseCasesPorts.CreateEmpleadoAsalariadoPorComision;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MediatrixPruebaTecnica.Controllers.EmpleadoControllers
{
    [Route("api/empleados")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class CreateEmpleadoAsalariadoPorComisionController : ControllerBase
    {
        private readonly ILogger<CreateEmpleadoAsalariadoPorComisionController> _logger;
        private readonly ICreateEmpleadoAsalariadoPorComisionInputPort _inputPort;
        private readonly ICreateEmpleadoAsalariadoPorComisionOutputPort _outputPort;

        public CreateEmpleadoAsalariadoPorComisionController(
            ILogger<CreateEmpleadoAsalariadoPorComisionController> logger,
            ICreateEmpleadoAsalariadoPorComisionInputPort inputPort,
            ICreateEmpleadoAsalariadoPorComisionOutputPort outputPort)
            => (_logger, _inputPort, _outputPort) = (logger, inputPort, outputPort);

        [HttpPost("asalariados-por-comision")]
        public async Task<IActionResult> Create(CreateEmpleadoAsalariadoPorComisionDto dto)
        {
            _logger.LogInformation("Iniciando creación de empleado asalariado por comisión. Nombre={PrimerNombre} {ApellidoPaterno}, NSS={NumeroSeguroSocial}, Departamento={Departamento}, SalarioBase={SalarioBase}, VentasBrutas={VentasBrutas}, TarifaComision={TarifaComision}",
                dto.PrimerNombre, dto.ApellidoPaterno, dto.NumeroSeguroSocial, dto.Departamento, dto.SalarioBase, dto.VentasBrutas, dto.TarifaComision);

            await _inputPort.Handle(dto);
            return Ok(_outputPort);
        }
    }
}
