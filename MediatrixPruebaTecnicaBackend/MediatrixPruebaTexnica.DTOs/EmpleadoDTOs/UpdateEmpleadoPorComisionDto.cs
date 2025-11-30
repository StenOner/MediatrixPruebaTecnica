namespace MediatrixPruebaTexnica.DTOs.EmpleadoDTOs
{
    public class UpdateEmpleadoPorComisionDto
    {
        public string PrimerNombre { get; set; } = string.Empty;
        public string ApellidoPaterno { get; set; } = string.Empty;
        public string Departamento { get; set; } = string.Empty;
        public decimal VentasBrutas { get; set; }
        public decimal TarifaComision { get; set; }
        public bool Activo { get; set; }
    }
}
