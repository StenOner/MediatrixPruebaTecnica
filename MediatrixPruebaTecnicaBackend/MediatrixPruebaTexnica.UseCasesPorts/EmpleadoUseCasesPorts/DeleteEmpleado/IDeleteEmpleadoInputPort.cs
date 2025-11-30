namespace MediatrixPruebaTexnica.UseCasesPorts.EmpleadoUseCasesPorts.DeleteEmpleado
{
    public interface IDeleteEmpleadoInputPort
    {
        Task Handle(Guid id);
    }
}
