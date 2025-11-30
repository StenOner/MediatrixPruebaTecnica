namespace MediatrixPruebaTexnica.DTOs.RegistroPagoDTOs
{
    public class RegistroPagoDto
    {
        public Guid Id { get; set; }
        public Guid EmpleadoId { get; set; }
        public string NombreEmpleado { get; set; } = string.Empty;
        public DateTime FechaPago { get; set; }
        public DateTime PeriodoInicio { get; set; }
        public DateTime PeriodoFin { get; set; }
        public decimal MontoBruto { get; set; }
        public decimal Deducciones { get; set; }
        public decimal MontoNeto { get; set; }
        public string? Observaciones { get; set; }
    }
}
