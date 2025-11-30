using MediatrixPruebaTexnica.DTOs.EmpleadoDTOs;

namespace MediatrixPruebaTexnica.UseCasesPorts.EmpleadoUseCasesPorts.UpdateEmpleadoAsalariado
{
    public interface IUpdateEmpleadoAsalariadoInputPort
    {
        Task Hanlde(Guid id, UpdateEmpleadoAsalariadoDto dto);
    }
}
