using MediatrixPruebaTexnica.DTOs.AuthDTOs;

namespace MediatrixPruebaTexnica.UseCasesPorts.AuthUseCasesPorts.Login
{
    public interface ILoginInputPort
    {
        Task Handle(LoginRequestDto dto);
    }
}
