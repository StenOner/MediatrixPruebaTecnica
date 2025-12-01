using MediatrixPruebaTexnica.DTOs.EmpleadoDTOs;

namespace MediatrixPruebaTexnica.UseCasesPorts.EmpleadoUseCasesPorts.CreateEmpleadoAsalariadoPorComision
{
    public interface ICreateEmpleadoAsalariadoPorComisionInputPort
    {
        Task Handle(CreateEmpleadoAsalariadoPorComisionDto dto);
    }
}
