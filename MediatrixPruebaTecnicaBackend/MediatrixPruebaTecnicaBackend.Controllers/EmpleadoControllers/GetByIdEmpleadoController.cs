using MediatrixPruebaTexnica.UseCasesPorts.EmpleadoUseCasesPorts.GetByIdEmpleado;
using Microsoft.AspNetCore.Mvc;

namespace MediatrixPruebaTecnica.Controllers.EmpleadoControllers
{
    [Route("api/empleados")]
    [ApiController]
    public class GetByIdEmpleadoController : ControllerBase
    {
        private readonly IGetByIdEmpleadoInputPort _inputPort;
        private readonly IGetByIdEmpleadoOutputPort _outputPort;

        public GetByIdEmpleadoController(IGetByIdEmpleadoInputPort inputPort, IGetByIdEmpleadoOutputPort outputPort)
            => (_inputPort, _outputPort) = (inputPort, outputPort);

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            await _inputPort.Handle(id);
            return Ok(_outputPort);
        }
    }
}
