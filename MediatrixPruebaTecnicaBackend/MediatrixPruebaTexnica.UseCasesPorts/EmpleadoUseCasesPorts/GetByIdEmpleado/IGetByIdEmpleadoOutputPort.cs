using MediatrixPruebaTexnica.DTOs.EmpleadoDTOs;
using MediatrixPruebaTexnica.UseCasesPorts.Common;

namespace MediatrixPruebaTexnica.UseCasesPorts.EmpleadoUseCasesPorts.GetByIdEmpleado
{
    public interface IGetByIdEmpleadoOutputPort
    {
        Task Handle(Result<EmpleadoDto> dto);
    }
}
