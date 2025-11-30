using MediatrixPruebaTexnica.DTOs.EmpleadoDTOs;

namespace MediatrixPruebaTexnica.UseCasesPorts.EmpleadoUseCasesPorts.UpdateEmpleadoPorComision
{
    public interface IUpdateEmpleadoPorComisionInputPort
    {
        Task Hanlde(Guid id, UpdateEmpleadoPorComisionDto dto);
    }
}
