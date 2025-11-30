using MediatrixPruebaTexnica.DTOs.EmpleadoDTOs;

namespace MediatrixPruebaTexnica.UseCasesPorts.EmpleadoUseCasesPorts.CreateEmpleadoPorComision
{
    public interface ICreateEmpleadoPorComisionInputPort
    {
        Task Handle(CreateEmpleadoPorComisionDto dto);
    }
}
