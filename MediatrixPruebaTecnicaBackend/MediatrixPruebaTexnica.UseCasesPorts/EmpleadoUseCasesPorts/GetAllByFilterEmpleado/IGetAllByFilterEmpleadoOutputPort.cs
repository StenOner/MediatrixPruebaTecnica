using MediatrixPruebaTexnica.DTOs.EmpleadoDTOs;
using MediatrixPruebaTexnica.UseCasesPorts.Common;

namespace MediatrixPruebaTexnica.UseCasesPorts.EmpleadoUseCasesPorts.GetAllByFilterEmpleado
{
    public interface IGetAllByFilterEmpleadoOutputPort
    {
        Task<Result<IEnumerable<EmpleadoDto>>> Handle(EmpleadoDto[] dto);
    }
}
