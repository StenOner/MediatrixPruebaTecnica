using MediatrixPruebaTecnica.Presenters;
using MediatrixPruebaTexnica.DTOs.AuthDTOs;
using MediatrixPruebaTexnica.UseCasesPorts.AuthUseCasesPorts.Login;
using Microsoft.AspNetCore.Mvc;

namespace MediatrixPruebaTecnica.Controllers.AuthControllers
{
    [Route("api/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginInputPort _inputPort;
        private readonly ILoginOutputPort _outputPort;

        public LoginController(ILoginInputPort inputPort, ILoginOutputPort outputPort)
            => (_inputPort, _outputPort) = (inputPort, outputPort);

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequestDto dto)
        {
            await _inputPort.Handle(dto);
            var content = ((IPresenter<LoginResponseDto>)_outputPort).Content;
            return Ok(content);
        }
    }
}
