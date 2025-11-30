using MediatrixPruebaTexnica.UseCasesPorts.EmpleadoUseCasesPorts.DeleteEmpleado;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MediatrixPruebaTecnica.Controllers.EmpleadoControllers
{
    [Route("api/empleados")]
    [ApiController]
    [Authorize]
    public class DeleteEmpleadoController : ControllerBase
    {
        private readonly IDeleteEmpleadoInputPort _inputPort;
        private readonly IDeleteEmpleadoOutputPort _outputPort;

        public DeleteEmpleadoController(IDeleteEmpleadoInputPort inputPort, IDeleteEmpleadoOutputPort outputPort)
            => (_inputPort, _outputPort) = (inputPort, outputPort);

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _inputPort.Handle(id);
            return Ok(_outputPort);
        }
    }
}
