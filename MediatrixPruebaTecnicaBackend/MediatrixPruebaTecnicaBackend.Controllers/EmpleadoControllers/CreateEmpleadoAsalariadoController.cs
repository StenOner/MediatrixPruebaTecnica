using MediatrixPruebaTexnica.DTOs.EmpleadoDTOs;
using MediatrixPruebaTexnica.UseCasesPorts.EmpleadoUseCasesPorts.CreateEmpleadoAsalariado;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MediatrixPruebaTecnica.Controllers.EmpleadoControllers
{
    [Route("api/empleados")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class CreateEmpleadoAsalariadoController : ControllerBase
    {
        private readonly ICreateEmpleadoAsalariadoInputPort _inputPort;
        private readonly ICreateEmpleadoAsalariadoOutputPort _outputPort;

        public CreateEmpleadoAsalariadoController(ICreateEmpleadoAsalariadoInputPort inputPort, ICreateEmpleadoAsalariadoOutputPort outputPort)
            => (_inputPort, _outputPort) = (inputPort, outputPort);

        [HttpPost("asalariados")]
        public async Task<IActionResult> Create(CreateEmpleadoAsalariadoDto dto)
        {
            await _inputPort.Handle(dto);
            return Ok(_outputPort);
        }
    }
}
