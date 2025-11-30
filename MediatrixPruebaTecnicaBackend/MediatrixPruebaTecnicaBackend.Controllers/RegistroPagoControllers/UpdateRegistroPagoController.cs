using MediatrixPruebaTexnica.DTOs.RegistroPagoDTOs;
using MediatrixPruebaTexnica.UseCasesPorts.RegistroPagoUseCasesPorts.UpdateRegistroPago;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MediatrixPruebaTecnica.Controllers.RegistroPagoControllers
{
    [Route("api/pagos")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class UpdateRegistroPagoController : ControllerBase
    {
        private readonly IUpdateRegistroPagoInputPort _inputPort;
        private readonly IUpdateRegistroPagoOutputPort _outputPort;

        public UpdateRegistroPagoController(IUpdateRegistroPagoInputPort inputPort, IUpdateRegistroPagoOutputPort outputPort)
            => (_inputPort, _outputPort) = (inputPort, outputPort);

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateRegistroPagoDto dto)
        {
            await _inputPort.Handle(id, dto);
            return Ok(_outputPort);
        }
    }
}
