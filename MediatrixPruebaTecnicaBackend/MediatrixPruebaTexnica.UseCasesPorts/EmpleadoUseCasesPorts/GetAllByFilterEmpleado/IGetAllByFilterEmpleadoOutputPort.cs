using MediatrixPruebaTexnica.DTOs.EmpleadoDTOs;
using MediatrixPruebaTexnica.UseCasesPorts.Common;

namespace MediatrixPruebaTexnica.UseCasesPorts.EmpleadoUseCasesPorts.GetAllByFilterEmpleado
{
    public interface IGetAllByFilterEmpleadoOutputPort
    {
        Task Handle(Result<IEnumerable<EmpleadoDto>> dtos);
    }
}
