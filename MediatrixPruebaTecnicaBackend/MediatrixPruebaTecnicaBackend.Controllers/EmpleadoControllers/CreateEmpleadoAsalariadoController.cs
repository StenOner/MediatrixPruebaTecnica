using MediatrixPruebaTexnica.DTOs.EmpleadoDTOs;
using MediatrixPruebaTexnica.UseCasesPorts.EmpleadoUseCasesPorts.CreateEmpleadoAsalariado;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MediatrixPruebaTecnica.Controllers.EmpleadoControllers
{
    [Route("api/empleados")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class CreateEmpleadoAsalariadoController : ControllerBase
    {
        private readonly ILogger<CreateEmpleadoAsalariadoController> _logger;
        private readonly ICreateEmpleadoAsalariadoInputPort _inputPort;
        private readonly ICreateEmpleadoAsalariadoOutputPort _outputPort;

        public CreateEmpleadoAsalariadoController(ILogger<CreateEmpleadoAsalariadoController> logger,ICreateEmpleadoAsalariadoInputPort inputPort, ICreateEmpleadoAsalariadoOutputPort outputPort)
            => (_logger, _inputPort, _outputPort) = (logger, inputPort, outputPort);

        [HttpPost("asalariados")]
        public async Task<IActionResult> Create(CreateEmpleadoAsalariadoDto dto)
        {
            _logger.LogInformation(
                "Iniciando creación de empleado asalariado. Nombre={PrimerNombre} {ApellidoPaterno}, NSS={NumeroSeguroSocial}, Departamento={Departamento}, SalarioSemanal={SalarioSemanal}",
                dto.PrimerNombre, dto.ApellidoPaterno, dto.NumeroSeguroSocial, dto.Departamento, dto.SalarioSemanal);
            await _inputPort.Handle(dto);
            return Ok(_outputPort);
        }
    }
}
