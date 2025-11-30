using MediatrixPruebaTexnica.DTOs.EmpleadoDTOs;
using MediatrixPruebaTexnica.UseCasesPorts.EmpleadoUseCasesPorts.CreateEmpleadoPorHoras;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MediatrixPruebaTecnica.Controllers.EmpleadoControllers
{
    [Route("api/empleados")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class CreateEmpleadoPorHorasController : ControllerBase
    {
        private readonly ICreateEmpleadoPorHorasInputPort _inputPort;
        private readonly ICreateEmpleadoPorHorasOutputPort _outputPort;

        public CreateEmpleadoPorHorasController(ICreateEmpleadoPorHorasInputPort inputPort, ICreateEmpleadoPorHorasOutputPort outputPort)
            => (_inputPort, _outputPort) = (inputPort, outputPort);

        [HttpPost("por-horas")]
        public async Task<IActionResult> Create(CreateEmpleadoPorHorasDto dto)
        {
            await _inputPort.Handle(dto);
            return Ok(_outputPort);
        }
    }
}
