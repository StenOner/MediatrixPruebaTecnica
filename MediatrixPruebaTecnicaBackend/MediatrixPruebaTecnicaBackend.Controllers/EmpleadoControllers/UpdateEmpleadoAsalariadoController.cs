using MediatrixPruebaTexnica.DTOs.EmpleadoDTOs;
using MediatrixPruebaTexnica.UseCasesPorts.EmpleadoUseCasesPorts.UpdateEmpleadoAsalariado;
using Microsoft.AspNetCore.Mvc;

namespace MediatrixPruebaTecnica.Controllers.EmpleadoControllers
{
    [Route("api/empleados")]
    [ApiController]
    public class UpdateEmpleadoAsalariadoController : ControllerBase
    {
        private readonly IUpdateEmpleadoAsalariadoInputPort _inputPort;
        private readonly IUpdateEmpleadoAsalariadoOutputPort _outputPort;

        public UpdateEmpleadoAsalariadoController(IUpdateEmpleadoAsalariadoInputPort inputPort, IUpdateEmpleadoAsalariadoOutputPort outputPort)
            => (_inputPort, _outputPort) = (inputPort, outputPort);

        [HttpPut("asalariados/{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateEmpleadoAsalariadoDto dto)
        {
            await _inputPort.Handle(id, dto);
            return Ok(_outputPort);
        }
    }
}
