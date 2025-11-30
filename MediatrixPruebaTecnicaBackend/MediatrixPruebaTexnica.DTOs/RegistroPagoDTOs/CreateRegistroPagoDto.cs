namespace MediatrixPruebaTexnica.DTOs.RegistroPagoDTOs
{
    public class CreateRegistroPagoDto
    {
        public Guid EmpleadoId { get; set; }
        public DateTime PeriodoInicio { get; set; }
        public DateTime PeriodoFin { get; set; }
        public decimal Deducciones { get; set; }
        public string? Observaciones { get; set; }
    }
}
