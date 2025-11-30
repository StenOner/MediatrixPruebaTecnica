using MediatrixPruebaTexnica.DTOs.EmpleadoDTOs;
using MediatrixPruebaTexnica.UseCasesPorts.Common;

namespace MediatrixPruebaTexnica.UseCasesPorts.EmpleadoUseCasesPorts.UpdateEmpleadoAsalariadoPorComision
{
    public interface IUpdateEmpleadoAsalariadoPorComisionOutputPort
    {
        Task<Result<EmpleadoDto>> Hanlde(EmpleadoDto empleadoDto);
    }
}
