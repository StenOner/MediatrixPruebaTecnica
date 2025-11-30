using MediatrixPruebaTexnica.UseCasesPorts.Common;

namespace MediatrixPruebaTexnica.UseCasesPorts.EmpleadoUseCasesPorts.DeleteEmpleado
{
    public interface IDeleteEmpleadoOutputPort
    {
        Task Handle(Result<bool> dto);
    }
}
