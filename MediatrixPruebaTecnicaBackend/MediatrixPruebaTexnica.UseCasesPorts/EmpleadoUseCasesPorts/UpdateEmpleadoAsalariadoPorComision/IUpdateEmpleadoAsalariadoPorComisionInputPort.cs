using MediatrixPruebaTexnica.DTOs.EmpleadoDTOs;

namespace MediatrixPruebaTexnica.UseCasesPorts.EmpleadoUseCasesPorts.UpdateEmpleadoAsalariadoPorComision
{
    public interface IUpdateEmpleadoAsalariadoPorComisionInputPort
    {
        Task Hanlde(Guid id, UpdateEmpleadoAsalariadoPorComisionDto dto);
    }
}
