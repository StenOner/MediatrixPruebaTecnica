using MediatrixPruebaTexnica.DTOs.EmpleadoDTOs;
using MediatrixPruebaTexnica.UseCasesPorts.Common;

namespace MediatrixPruebaTexnica.UseCasesPorts.EmpleadoUseCasesPorts.CreateEmpleadoPorComision
{
    public interface ICreateEmpleadoPorComisionOutputPort
    {
        Task Handle(Result<EmpleadoDto> dto);
    }
}
