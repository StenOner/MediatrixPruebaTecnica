using MediatrixPruebaTexnica.DTOs.EmpleadoDTOs;
using MediatrixPruebaTexnica.UseCasesPorts.Common;

namespace MediatrixPruebaTexnica.UseCasesPorts.EmpleadoUseCasesPorts.UpdateEmpleadoAsalariadoPorComision
{
    public interface IUpdateEmpleadoAsalariadoPorComisionOutputPort
    {
        Task Handle(Result<EmpleadoDto> dto);
    }
}
