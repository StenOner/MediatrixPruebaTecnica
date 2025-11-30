using MediatrixPruebaTexnica.DTOs.EmpleadoDTOs;

namespace MediatrixPruebaTexnica.UseCasesPorts.EmpleadoUseCasesPorts.UpdateEmpleadoAsalariadoPorComision
{
    public interface IUpdateEmpleadoAsalariadoPorComisionInputPort
    {
        Task Handle(Guid id, UpdateEmpleadoAsalariadoPorComisionDto dto);
    }
}
