namespace MediatrixPruebaTexnica.DTOs.EmpleadoDTOs
{
    public class UpdateEmpleadoAsalariadoDto
    {
        public string PrimerNombre { get; set; } = string.Empty;
        public string ApellidoPaterno { get; set; } = string.Empty;
        public string Departamento { get; set; } = string.Empty;
        public decimal SalarioSemanal { get; set; }
        public bool Activo { get; set; }
    }
}
