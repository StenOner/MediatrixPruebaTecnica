using MediatrixPruebaTexnica.DTOs.EmpleadoDTOs;
using MediatrixPruebaTexnica.UseCasesPorts.EmpleadoUseCasesPorts.CreateEmpleadoPorComision;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MediatrixPruebaTecnica.Controllers.EmpleadoControllers
{
    [Route("api/empleados")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class CreateEmpleadoPorComisionController : ControllerBase
    {
        private readonly ICreateEmpleadoPorComisionInputPort _inputPort;
        private readonly ICreateEmpleadoPorComisionOutputPort _outputPort;

        public CreateEmpleadoPorComisionController(ICreateEmpleadoPorComisionInputPort inputPort, ICreateEmpleadoPorComisionOutputPort outputPort)
            => (_inputPort, _outputPort) = (inputPort, outputPort);

        [HttpPost("por-comision")]
        public async Task<IActionResult> Create(CreateEmpleadoPorComisionDto dto)
        {
            await _inputPort.Handle(dto);
            return Ok(_outputPort);
        }
    }
}
