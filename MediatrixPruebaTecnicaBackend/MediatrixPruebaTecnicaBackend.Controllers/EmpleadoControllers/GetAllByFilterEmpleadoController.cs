using MediatrixPruebaTexnica.DTOs.EmpleadoDTOs;
using MediatrixPruebaTexnica.UseCasesPorts.EmpleadoUseCasesPorts.GetAllByFilterEmpleado;
using Microsoft.AspNetCore.Mvc;

namespace MediatrixPruebaTecnica.Controllers.EmpleadoControllers
{
    [Route("api/empleados")]
    [ApiController]
    public class GetAllByFilterEmpleadoController : ControllerBase
    {
        private readonly IGetAllByFilterEmpleadoInputPort _inputPort;
        private readonly IGetAllByFilterEmpleadoOutputPort _outputPort;

        public GetAllByFilterEmpleadoController(IGetAllByFilterEmpleadoInputPort inputPort, IGetAllByFilterEmpleadoOutputPort outputPort)
            => (_inputPort, _outputPort) = (inputPort, outputPort);

        [HttpGet("filter")]
        public async Task<IActionResult> GetAll([FromQuery] EmpleadoFiltroDto dto)
        {
            await _inputPort.Handle(dto);
            return Ok(_outputPort);
        }
    }
}
