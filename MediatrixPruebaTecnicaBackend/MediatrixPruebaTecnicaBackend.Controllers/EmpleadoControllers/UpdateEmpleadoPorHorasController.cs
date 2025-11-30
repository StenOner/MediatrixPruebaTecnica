using MediatrixPruebaTexnica.DTOs.EmpleadoDTOs;
using MediatrixPruebaTexnica.UseCasesPorts.EmpleadoUseCasesPorts.UpdateEmpleadoPorHoras;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MediatrixPruebaTecnica.Controllers.EmpleadoControllers
{
    [Route("api/empleados")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class UpdateEmpleadoPorHorasController : ControllerBase
    {
        private readonly IUpdateEmpleadoPorHorasInputPort _inputPort;
        private readonly IUpdateEmpleadoPorHorasOutputPort _outputPort;

        public UpdateEmpleadoPorHorasController(IUpdateEmpleadoPorHorasInputPort inputPort, IUpdateEmpleadoPorHorasOutputPort outputPort)
            => (_inputPort, _outputPort) = (inputPort, outputPort);

        [HttpPut("por-horas/{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateEmpleadoPorHorasDto dto)
        {
            await _inputPort.Handle(id, dto);
            return Ok(_outputPort);
        }
    }
}
