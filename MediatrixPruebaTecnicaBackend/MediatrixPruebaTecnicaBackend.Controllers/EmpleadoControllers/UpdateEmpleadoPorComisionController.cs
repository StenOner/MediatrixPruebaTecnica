using MediatrixPruebaTexnica.DTOs.EmpleadoDTOs;
using MediatrixPruebaTexnica.UseCasesPorts.EmpleadoUseCasesPorts.UpdateEmpleadoPorComision;
using Microsoft.AspNetCore.Mvc;

namespace MediatrixPruebaTecnica.Controllers.EmpleadoControllers
{
    [Route("api/empleados")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class UpdateEmpleadoPorComisionController : ControllerBase
    {
        private readonly IUpdateEmpleadoPorComisionInputPort _inputPort;
        private readonly IUpdateEmpleadoPorComisionOutputPort _outputPort;

        public UpdateEmpleadoPorComisionController(IUpdateEmpleadoPorComisionInputPort inputPort, IUpdateEmpleadoPorComisionOutputPort outputPort)
            => (_inputPort, _outputPort) = (inputPort, outputPort);

        [HttpPut("por-comision/{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateEmpleadoPorComisionDto dto)
        {
            await _inputPort.Handle(id, dto);
            return Ok(_outputPort);
        }
    }
}
