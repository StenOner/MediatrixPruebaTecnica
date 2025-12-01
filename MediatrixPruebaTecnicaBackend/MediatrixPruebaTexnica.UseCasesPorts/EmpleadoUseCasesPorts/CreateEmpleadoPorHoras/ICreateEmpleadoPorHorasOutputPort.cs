using MediatrixPruebaTexnica.DTOs.EmpleadoDTOs;
using MediatrixPruebaTexnica.UseCasesPorts.Common;

namespace MediatrixPruebaTexnica.UseCasesPorts.EmpleadoUseCasesPorts.CreateEmpleadoPorHoras
{
    public interface ICreateEmpleadoPorHorasOutputPort
    {
        Task Handle(Result<EmpleadoDto> dto);
    }
}
