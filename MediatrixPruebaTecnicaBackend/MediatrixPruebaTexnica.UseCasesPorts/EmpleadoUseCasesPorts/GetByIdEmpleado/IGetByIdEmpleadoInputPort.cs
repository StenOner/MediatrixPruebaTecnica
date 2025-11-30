namespace MediatrixPruebaTexnica.UseCasesPorts.EmpleadoUseCasesPorts.GetByIdEmpleado
{
    public interface IGetByIdEmpleadoInputPort
    {
        Task Hanlde(Guid id);
    }
}
