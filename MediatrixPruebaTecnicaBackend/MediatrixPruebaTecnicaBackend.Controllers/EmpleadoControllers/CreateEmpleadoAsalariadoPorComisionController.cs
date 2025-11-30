using MediatrixPruebaTexnica.DTOs.EmpleadoDTOs;
using MediatrixPruebaTexnica.UseCasesPorts.EmpleadoUseCasesPorts.CreateEmpleadoAsalariadoPorComision;
using Microsoft.AspNetCore.Mvc;

namespace MediatrixPruebaTecnica.Controllers.EmpleadoControllers
{
    [Route("api/empleados")]
    [ApiController]
    public class CreateEmpleadoAsalariadoPorComisionController : ControllerBase
    {
        private readonly ICreateEmpleadoAsalariadoPorComisionInputPort _inputPort;
        private readonly ICreateEmpleadoAsalariadoPorComisionOutputPort _outputPort;

        public CreateEmpleadoAsalariadoPorComisionController(ICreateEmpleadoAsalariadoPorComisionInputPort inputPort, ICreateEmpleadoAsalariadoPorComisionOutputPort outputPort)
            => (_inputPort, _outputPort) = (inputPort, outputPort);

        [HttpPost("asalariados-por-comision")]
        public async Task<IActionResult> Create(CreateEmpleadoAsalariadoPorComisionDto dto)
        {
            await _inputPort.Handle(dto);
            return Ok(_outputPort);
        }
    }
}
