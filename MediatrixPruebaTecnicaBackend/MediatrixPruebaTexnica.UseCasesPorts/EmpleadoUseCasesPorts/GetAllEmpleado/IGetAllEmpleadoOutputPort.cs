using MediatrixPruebaTexnica.DTOs.EmpleadoDTOs;
using MediatrixPruebaTexnica.UseCasesPorts.Common;

namespace MediatrixPruebaTexnica.UseCasesPorts.EmpleadoUseCasesPorts.GetAllEmpleado
{
    public interface IGetAllEmpleadoOutputPort
    {
        Task<Result<IEnumerable<EmpleadoDto>>> Handle(Result<IEnumerable<EmpleadoDto>> dtos);
    }
}
