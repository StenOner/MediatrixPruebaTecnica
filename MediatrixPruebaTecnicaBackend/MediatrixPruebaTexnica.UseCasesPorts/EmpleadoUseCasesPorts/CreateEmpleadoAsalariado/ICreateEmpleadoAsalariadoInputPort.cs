using MediatrixPruebaTexnica.DTOs.EmpleadoDTOs;

namespace MediatrixPruebaTexnica.UseCasesPorts.EmpleadoUseCasesPorts.CreateEmpleadoAsalariado
{
    public interface ICreateEmpleadoAsalariadoInputPort
    {
        Task Handle(CreateEmpleadoAsalariadoDto dto);
    }
}
