using MediatrixPruebaTexnica.DTOs.AuthDTOs;
using MediatrixPruebaTexnica.UseCasesPorts.Common;

namespace MediatrixPruebaTexnica.UseCasesPorts.AuthUseCasesPorts.Login
{
    public interface ILoginOutputPort
    {
        Task Handle(Result<LoginResponseDto> dto);
    }
}
