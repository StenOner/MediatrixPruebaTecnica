using MediatrixPruebaTexnica.DTOs.EmpleadoDTOs;

namespace MediatrixPruebaTexnica.UseCasesPorts.EmpleadoUseCasesPorts.UpdateEmpleadoPorHoras
{
    public interface IUpdateEmpleadoPorHorasInputPort
    {
        Task Hanlde(Guid id, UpdateEmpleadoPorHorasDto dto);
    }
}
