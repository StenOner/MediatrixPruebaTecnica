using MediatrixPruebaTexnica.DTOs.EmpleadoDTOs;
using MediatrixPruebaTexnica.UseCasesPorts.EmpleadoUseCasesPorts.UpdateEmpleadoPorHoras;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MediatrixPruebaTecnica.Controllers.EmpleadoControllers
{
    [Route("api/empleados")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class UpdateEmpleadoPorHorasController : ControllerBase
    {
        private readonly ILogger<UpdateEmpleadoPorHorasController> _logger;
        private readonly IUpdateEmpleadoPorHorasInputPort _inputPort;
        private readonly IUpdateEmpleadoPorHorasOutputPort _outputPort;

        public UpdateEmpleadoPorHorasController(
            ILogger<UpdateEmpleadoPorHorasController> logger,
            IUpdateEmpleadoPorHorasInputPort inputPort,
            IUpdateEmpleadoPorHorasOutputPort outputPort)
            => (_logger, _inputPort, _outputPort) = (logger, inputPort, outputPort);

        [HttpPut("por-horas/{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateEmpleadoPorHorasDto dto)
        {
            _logger.LogInformation(
                "Iniciando actualización de empleado por horas. Id={Id}, Nombre={PrimerNombre} {ApellidoPaterno}, SueldoPorHora={SueldoPorHora}, HorasTrabajadas={HorasTrabajadas}, Activo={Activo}",
                id, dto.PrimerNombre, dto.ApellidoPaterno, dto.SueldoPorHora, dto.HorasTrabajadas, dto.Activo);

            await _inputPort.Handle(id, dto);
            return Ok(_outputPort);
        }
    }
}
