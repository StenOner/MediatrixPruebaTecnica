using MediatrixPruebaTecnica.Entities.Bases;

namespace MediatrixPruebaTecnica.Entities.POCOs
{
    public class RegistroPago
    {
        public Guid Id { get; set; }
        public Guid EmpleadoId { get; set; }
        public Empleado Empleado { get; set; } = null!;

        public DateTime FechaPago { get; set; }
        public DateTime PeriodoInicio { get; set; }
        public DateTime PeriodoFin { get; set; }

        public decimal MontoBruto { get; set; }
        public decimal Deducciones { get; set; }
        public decimal MontoNeto { get; set; }

        public string? Observaciones { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
