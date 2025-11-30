using MediatrixPruebaTexnica.DTOs.EmpleadoDTOs;
using MediatrixPruebaTexnica.UseCasesPorts.Common;

namespace MediatrixPruebaTexnica.UseCasesPorts.EmpleadoUseCasesPorts.GetAllEmpleado
{
    public interface IGetAllEmpleadoOutputPort
    {
        Task Handle(Result<IEnumerable<EmpleadoDto>> dtos);
    }
}
