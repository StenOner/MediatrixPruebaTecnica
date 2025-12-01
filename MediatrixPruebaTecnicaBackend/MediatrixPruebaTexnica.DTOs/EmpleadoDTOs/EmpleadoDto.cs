namespace MediatrixPruebaTexnica.DTOs.EmpleadoDTOs
{
    public class EmpleadoDto
    {
        public Guid Id { get; set; }
        public string PrimerNombre { get; set; } = string.Empty;
        public string ApellidoPaterno { get; set; } = string.Empty;
        public string NumeroSeguroSocial { get; set; } = string.Empty;
        public string Departamento { get; set; } = string.Empty;
        public DateTime FechaContratacion { get; set; }
        public bool Activo { get; set; }
        public string TipoEmpleado { get; set; } = string.Empty;
        public decimal PagoSemanal { get; set; }
    }
}
