using MediatrixPruebaTexnica.DTOs.EmpleadoDTOs;
using MediatrixPruebaTexnica.UseCasesPorts.Common;

namespace MediatrixPruebaTexnica.UseCasesPorts.EmpleadoUseCasesPorts.CreateEmpleadoAsalariado
{
    public interface ICreateEmpleadoAsalariadoOutputPort
    {
        Task Handle(EmpleadoDto dto);
    }
}
