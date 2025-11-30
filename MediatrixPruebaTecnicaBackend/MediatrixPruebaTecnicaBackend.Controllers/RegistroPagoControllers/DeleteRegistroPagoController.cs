using MediatrixPruebaTexnica.UseCasesPorts.RegistroPagoUseCasesPorts.DeleteRegistroPago;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MediatrixPruebaTecnica.Controllers.RegistroPagoControllers
{
    [Route("api/pagos")]
    [ApiController]
    [Authorize]
    public class DeleteRegistroPagoController : ControllerBase
    {
        private readonly IDeleteRegistroPagoInputPort _inputPort;
        private readonly IDeleteRegistroPagoOutputPort _outputPort;

        public DeleteRegistroPagoController(IDeleteRegistroPagoInputPort inputPort, IDeleteRegistroPagoOutputPort outputPort)
            => (_inputPort, _outputPort) = (inputPort, outputPort);

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _inputPort.Handle(id);
            return Ok(_outputPort);
        }
    }
}
