using MediatrixPruebaTexnica.DTOs.EmpleadoDTOs;

namespace MediatrixPruebaTexnica.UseCasesPorts.EmpleadoUseCasesPorts.UpdateEmpleadoPorComision
{
    public interface IUpdateEmpleadoPorComisionInputPort
    {
        Task Handle(Guid id, UpdateEmpleadoPorComisionDto dto);
    }
}
