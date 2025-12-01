using MediatrixPruebaTexnica.DTOs.EmpleadoDTOs;
using MediatrixPruebaTexnica.UseCasesPorts.EmpleadoUseCasesPorts.CreateEmpleadoPorComision;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MediatrixPruebaTecnica.Controllers.EmpleadoControllers
{
    [Route("api/empleados")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class CreateEmpleadoPorComisionController : ControllerBase
    {
        private readonly ILogger<CreateEmpleadoPorComisionController> _logger;
        private readonly ICreateEmpleadoPorComisionInputPort _inputPort;
        private readonly ICreateEmpleadoPorComisionOutputPort _outputPort;

        public CreateEmpleadoPorComisionController(
            ILogger<CreateEmpleadoPorComisionController> logger,
            ICreateEmpleadoPorComisionInputPort inputPort,
            ICreateEmpleadoPorComisionOutputPort outputPort)
            => (_logger, _inputPort, _outputPort) = (logger, inputPort, outputPort);

        [HttpPost("por-comision")]
        public async Task<IActionResult> Create(CreateEmpleadoPorComisionDto dto)
        {
            _logger.LogInformation(
                "Iniciando creación de empleado por comisión. Nombre={PrimerNombre} {ApellidoPaterno}, NSS={NumeroSeguroSocial}, Departamento={Departamento}, VentasBrutas={VentasBrutas}, TarifaComision={TarifaComision}",
                dto.PrimerNombre, dto.ApellidoPaterno, dto.NumeroSeguroSocial, dto.Departamento, dto.VentasBrutas, dto.TarifaComision);

            await _inputPort.Handle(dto);
            return Ok(_outputPort);
        }
    }
}
