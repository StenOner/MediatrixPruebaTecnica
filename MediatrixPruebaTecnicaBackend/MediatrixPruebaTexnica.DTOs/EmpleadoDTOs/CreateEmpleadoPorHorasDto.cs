namespace MediatrixPruebaTexnica.DTOs.EmpleadoDTOs
{
    public class CreateEmpleadoPorHorasDto
    {
        public string PrimerNombre { get; set; } = string.Empty;
        public string ApellidoPaterno { get; set; } = string.Empty;
        public string NumeroSeguroSocial { get; set; } = string.Empty;
        public string Departamento { get; set; } = string.Empty;
        public decimal SueldoPorHora { get; set; }
        public decimal HorasTrabajadas { get; set; }
    }
}
