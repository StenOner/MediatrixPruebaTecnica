using MediatrixPruebaTexnica.DTOs.EmpleadoDTOs;

namespace MediatrixPruebaTexnica.UseCasesPorts.EmpleadoUseCasesPorts.UpdateEmpleadoAsalariado
{
    public interface IUpdateEmpleadoAsalariadoInputPort
    {
        Task Handle(Guid id, UpdateEmpleadoAsalariadoDto dto);
    }
}
