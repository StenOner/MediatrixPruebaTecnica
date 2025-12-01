namespace MediatrixPruebaTexnica.DTOs.EmpleadoDTOs
{
    public class CreateEmpleadoAsalariadoPorComisionDto
    {
        public string PrimerNombre { get; set; } = string.Empty;
        public string ApellidoPaterno { get; set; } = string.Empty;
        public string NumeroSeguroSocial { get; set; } = string.Empty;
        public string Departamento { get; set; } = string.Empty;
        public decimal SalarioBase { get; set; }
        public decimal VentasBrutas { get; set; }
        public decimal TarifaComision { get; set; }
    }
}
