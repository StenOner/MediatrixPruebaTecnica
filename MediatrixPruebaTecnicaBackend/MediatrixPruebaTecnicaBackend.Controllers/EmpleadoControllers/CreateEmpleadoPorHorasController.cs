using MediatrixPruebaTexnica.DTOs.EmpleadoDTOs;
using MediatrixPruebaTexnica.UseCasesPorts.EmpleadoUseCasesPorts.CreateEmpleadoPorHoras;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MediatrixPruebaTecnica.Controllers.EmpleadoControllers
{
    [Route("api/empleados")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class CreateEmpleadoPorHorasController : ControllerBase
    {
        private readonly ILogger<CreateEmpleadoPorHorasController> _logger;
        private readonly ICreateEmpleadoPorHorasInputPort _inputPort;
        private readonly ICreateEmpleadoPorHorasOutputPort _outputPort;

        public CreateEmpleadoPorHorasController(
            ILogger<CreateEmpleadoPorHorasController> logger,
            ICreateEmpleadoPorHorasInputPort inputPort,
            ICreateEmpleadoPorHorasOutputPort outputPort)
            => (_logger, _inputPort, _outputPort) = (logger, inputPort, outputPort);

        [HttpPost("por-horas")]
        public async Task<IActionResult> Create(CreateEmpleadoPorHorasDto dto)
        {
            _logger.LogInformation(
                "Iniciando creación de empleado por horas. Nombre={PrimerNombre} {ApellidoPaterno}, NSS={NumeroSeguroSocial}, Departamento={Departamento}, SueldoPorHora={SueldoPorHora}, HorasTrabajadas={HorasTrabajadas}",
                dto.PrimerNombre, dto.ApellidoPaterno, dto.NumeroSeguroSocial, dto.Departamento, dto.SueldoPorHora, dto.HorasTrabajadas);

            await _inputPort.Handle(dto);
            return Ok(_outputPort);
        }
    }
}
