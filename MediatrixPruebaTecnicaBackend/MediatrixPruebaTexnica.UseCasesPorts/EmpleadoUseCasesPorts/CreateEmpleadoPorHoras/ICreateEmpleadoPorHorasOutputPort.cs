using MediatrixPruebaTexnica.DTOs.EmpleadoDTOs;
using MediatrixPruebaTexnica.UseCasesPorts.Common;

namespace MediatrixPruebaTexnica.UseCasesPorts.EmpleadoUseCasesPorts.CreateEmpleadoPorHoras
{
    public interface ICreateEmpleadoPorHorasOutputPort
    {
        Task<Result<EmpleadoDto>> Handle(EmpleadoDto dto);
    }
}
