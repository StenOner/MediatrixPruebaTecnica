using MediatrixPruebaTexnica.DTOs.EmpleadoDTOs;

namespace MediatrixPruebaTexnica.UseCasesPorts.EmpleadoUseCasesPorts.GetAllByFilterEmpleado
{
    public interface IGetAllByFilterEmpleadoInputPort
    {
        Task Handle(EmpleadoFiltroDto dto);
    }
}
