using MediatrixPruebaTexnica.DTOs.EmpleadoDTOs;
using MediatrixPruebaTexnica.UseCasesPorts.Common;

namespace MediatrixPruebaTexnica.UseCasesPorts.EmpleadoUseCasesPorts.CreateEmpleadoAsalariadoPorComision
{
    public interface ICreateEmpleadoAsalariadoPorComisionOutputPort
    {
        Task<Result<EmpleadoDto>> Handle(EmpleadoDto dto);
    }
}
