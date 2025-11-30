using MediatrixPruebaTexnica.DTOs.EmpleadoDTOs;
using MediatrixPruebaTexnica.UseCasesPorts.Common;

namespace MediatrixPruebaTexnica.UseCasesPorts.EmpleadoUseCasesPorts.UpdateEmpleadoPorComision
{
    public interface IUpdateEmpleadoPorComisionOutputPort
    {
        Task Handle(Result<EmpleadoDto> empleadoDto);
    }
}
