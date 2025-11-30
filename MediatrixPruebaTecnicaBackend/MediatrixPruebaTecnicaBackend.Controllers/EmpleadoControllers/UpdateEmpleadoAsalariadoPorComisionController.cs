using MediatrixPruebaTexnica.DTOs.EmpleadoDTOs;
using MediatrixPruebaTexnica.UseCasesPorts.EmpleadoUseCasesPorts.UpdateEmpleadoAsalariadoPorComision;
using Microsoft.AspNetCore.Mvc;

namespace MediatrixPruebaTecnica.Controllers.EmpleadoControllers
{
    [Route("api/empleados")]
    [ApiController]
    public class UpdateEmpleadoAsalariadoPorComisionController : ControllerBase
    {
        private readonly IUpdateEmpleadoAsalariadoPorComisionInputPort _inputPort;
        private readonly IUpdateEmpleadoAsalariadoPorComisionOutputPort _outputPort;

        public UpdateEmpleadoAsalariadoPorComisionController(IUpdateEmpleadoAsalariadoPorComisionInputPort inputPort, IUpdateEmpleadoAsalariadoPorComisionOutputPort outputPort)
            => (_inputPort, _outputPort) = (inputPort, outputPort);

        [HttpPut("asalariados-por-comision/{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateEmpleadoAsalariadoPorComisionDto dto)
        {
            await _inputPort.Handle(id, dto);
            return Ok(_outputPort);
        }
    }
}
