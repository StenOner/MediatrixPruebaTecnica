namespace MediatrixPruebaTexnica.UseCasesPorts.RegistroPagoUseCasesPorts.GetReportePago
{
    public interface IGetReportePagoInputPort
    {
        Task Handle(DateTime inicio, DateTime fin);
    }
}
