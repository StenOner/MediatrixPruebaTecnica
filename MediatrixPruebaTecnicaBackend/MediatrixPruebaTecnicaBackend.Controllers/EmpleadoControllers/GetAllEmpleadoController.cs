using MediatrixPruebaTexnica.UseCasesPorts.EmpleadoUseCasesPorts.GetAllEmpleado;
using Microsoft.AspNetCore.Mvc;

namespace MediatrixPruebaTecnica.Controllers.EmpleadoControllers
{
    [Route("api/empleados")]
    [ApiController]
    public class GetAllEmpleadoController : ControllerBase
    {
        private readonly IGetAllEmpleadoInputPort _inputPort;
        private readonly IGetAllEmpleadoOutputPort _outputPort;

        public GetAllEmpleadoController(IGetAllEmpleadoInputPort inputPort, IGetAllEmpleadoOutputPort outputPort)
            => (_inputPort, _outputPort) = (inputPort, outputPort);

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            await _inputPort.Handle();
            return Ok(_outputPort);
        }
    }
}
