using MediatrixPruebaTexnica.DTOs.EmpleadoDTOs;
using MediatrixPruebaTexnica.UseCasesPorts.Common;

namespace MediatrixPruebaTexnica.UseCasesPorts.EmpleadoUseCasesPorts.GetByIdEmpleado
{
    public interface IGetByIdEmpleadoOutputPort
    {
        Task<Result<EmpleadoDto>> Hanlde(EmpleadoDto dto);
    }
}
