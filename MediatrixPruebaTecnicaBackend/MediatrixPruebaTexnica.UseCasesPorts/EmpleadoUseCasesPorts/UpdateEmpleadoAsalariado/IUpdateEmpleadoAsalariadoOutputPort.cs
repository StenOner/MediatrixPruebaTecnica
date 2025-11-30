using MediatrixPruebaTexnica.DTOs.EmpleadoDTOs;
using MediatrixPruebaTexnica.UseCasesPorts.Common;

namespace MediatrixPruebaTexnica.UseCasesPorts.EmpleadoUseCasesPorts.UpdateEmpleadoAsalariado
{
    public interface IUpdateEmpleadoAsalariadoOutputPort
    {
        Task<Result<EmpleadoDto>> Hanlde(EmpleadoDto empleadoDto);
    }
}
