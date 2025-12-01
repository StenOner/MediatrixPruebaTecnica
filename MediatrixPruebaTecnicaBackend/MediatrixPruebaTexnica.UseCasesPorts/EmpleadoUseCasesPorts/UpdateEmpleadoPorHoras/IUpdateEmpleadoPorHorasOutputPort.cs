using MediatrixPruebaTexnica.DTOs.EmpleadoDTOs;
using MediatrixPruebaTexnica.UseCasesPorts.Common;

namespace MediatrixPruebaTexnica.UseCasesPorts.EmpleadoUseCasesPorts.UpdateEmpleadoPorHoras
{
    public interface IUpdateEmpleadoPorHorasOutputPort
    {
        Task Handle(Result<EmpleadoDto> empleadoDto);
    }
}
