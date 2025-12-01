using MediatrixPruebaTexnica.DTOs.EmpleadoDTOs;

namespace MediatrixPruebaTexnica.UseCasesPorts.EmpleadoUseCasesPorts.CreateEmpleadoPorHoras
{
    public interface ICreateEmpleadoPorHorasInputPort
    {
        Task Handle(CreateEmpleadoPorHorasDto dto);
    }
}
