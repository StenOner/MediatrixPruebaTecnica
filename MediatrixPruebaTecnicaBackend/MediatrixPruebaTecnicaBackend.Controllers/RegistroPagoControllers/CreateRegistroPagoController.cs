using MediatrixPruebaTexnica.DTOs.RegistroPagoDTOs;
using MediatrixPruebaTexnica.UseCasesPorts.RegistroPagoUseCasesPorts.CreateRegistroPago;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MediatrixPruebaTecnica.Controllers.RegistroPagoControllers
{
    [Route("api/pagos")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class CreateRegistroPagoController : ControllerBase
    {
        private readonly ICreateRegistroPagoInputPort _inputPort;
        private readonly ICreateRegistroPagoOutputPort _outputPort;

        public CreateRegistroPagoController(ICreateRegistroPagoInputPort inputPort, ICreateRegistroPagoOutputPort outputPort)
            => (_inputPort, _outputPort) = (inputPort, outputPort);

        [HttpPost]
        public async Task<IActionResult> Create(CreateRegistroPagoDto dto)
        {
            await _inputPort.Handle(dto);
            return Ok(_outputPort);
        }
    }
}
