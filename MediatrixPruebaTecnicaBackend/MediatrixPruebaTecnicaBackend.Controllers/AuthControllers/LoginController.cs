using MediatrixPruebaTexnica.DTOs.AuthDTOs;
using MediatrixPruebaTexnica.UseCasesPorts.AuthUseCasesPorts.Login;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MediatrixPruebaTecnica.Controllers.AuthControllers
{
    [Route("api/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILogger<LoginController> _logger;
        private readonly ILoginInputPort _inputPort;
        private readonly ILoginOutputPort _outputPort;

        public LoginController(ILogger<LoginController> logger, ILoginInputPort inputPort, ILoginOutputPort outputPort)
            => (_logger, _inputPort, _outputPort) = (logger, inputPort, outputPort);

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequestDto dto)
        {
            _logger.LogInformation("Intento de logeo para usuario={NombreUsuario}", dto.NombreUsuario);
            await _inputPort.Handle(dto);
            _logger.LogInformation("Intento de logeo finalizado para usuario={NombreUsuario}", dto.NombreUsuario);
            return Ok(_outputPort);
        }
    }
}
