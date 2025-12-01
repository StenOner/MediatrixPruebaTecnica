using MediatrixPruebaTexnica.DTOs.EmpleadoDTOs;

namespace MediatrixPruebaTexnica.UseCasesPorts.EmpleadoUseCasesPorts.UpdateEmpleadoPorHoras
{
    public interface IUpdateEmpleadoPorHorasInputPort
    {
        Task Handle(Guid id, UpdateEmpleadoPorHorasDto dto);
    }
}
