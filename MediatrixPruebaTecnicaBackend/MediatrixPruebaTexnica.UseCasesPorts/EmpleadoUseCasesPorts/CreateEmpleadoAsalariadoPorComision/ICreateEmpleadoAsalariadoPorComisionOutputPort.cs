using MediatrixPruebaTexnica.DTOs.EmpleadoDTOs;
using MediatrixPruebaTexnica.UseCasesPorts.Common;

namespace MediatrixPruebaTexnica.UseCasesPorts.EmpleadoUseCasesPorts.CreateEmpleadoAsalariadoPorComision
{
    public interface ICreateEmpleadoAsalariadoPorComisionOutputPort
    {
        Task Handle(Result<EmpleadoDto> dto);
    }
}
