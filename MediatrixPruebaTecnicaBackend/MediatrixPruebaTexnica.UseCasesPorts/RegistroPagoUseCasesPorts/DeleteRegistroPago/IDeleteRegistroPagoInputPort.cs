namespace MediatrixPruebaTexnica.UseCasesPorts.RegistroPagoUseCasesPorts.DeleteRegistroPago
{
    public interface IDeleteRegistroPagoInputPort
    {
        Task Handle(Guid id);
    }
}
