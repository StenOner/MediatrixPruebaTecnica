namespace MediatrixPruebaTexnica.UseCasesPorts.EmpleadoUseCasesPorts.GetByIdEmpleado
{
    public interface IGetByIdEmpleadoInputPort
    {
        Task Handle(Guid id);
    }
}
