namespace MediatrixPruebaTexnica.DTOs.RegistroPagoDTOs
{
    public class ReportePagosDto
    {
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public List<RegistroPagoDto> Pagos { get; set; } = [];
        public decimal TotalBruto { get; set; }
        public decimal TotalDeducciones { get; set; }
        public decimal TotalNeto { get; set; }
    }
}
