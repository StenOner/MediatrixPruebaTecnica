using MediatrixPruebaTexnica.DTOs.AuthDTOs;
using MediatrixPruebaTexnica.UseCasesPorts.AuthUseCasesPorts.Login;
using MediatrixPruebaTexnica.UseCasesPorts.Common;

namespace MediatrixPruebaTecnica.Presenters.AuthPresenters
{
    public class LoginPresenter : ILoginOutputPort, IPresenter<Result<LoginResponseDto>>
    {
        public Result<LoginResponseDto> Content { get; private set; } = new();

        public Task Handle(Result<LoginResponseDto> content)
        {
            Content = content;
            return Task.CompletedTask;
        }
    }
}
